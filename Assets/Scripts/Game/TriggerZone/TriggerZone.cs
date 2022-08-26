using UnityEngine;
using System.Collections;
using System;

public class TriggerZone : MonoBehaviour
{
    public enum TriggerType
    {
        Die,Notification,GameFinish,Popup
    }

    public TriggerType triggerType;

    private Player player;

    [Header("PopUpHandler")]
    public PopUpStorage popUpStorage;

    [Header("Notification")]
    public NotificationData notificationData;
    public ThisApp sendToApp;

    public static event Action GameOverEvent, LevelCompleteEvent;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (triggerType)
            {
                case TriggerType.Die:
                    SoundManager sm = FindObjectOfType<SoundManager>();
                    sm.PlaySound(sm.DieSound);
                    if (player)
                    {
                        Destroy(player.gameObject);
                        GameOverEvent?.Invoke();
                    }
                    break;

                case TriggerType.Notification:
                    sendToApp.AddNotification(notificationData);
                    if(DataHandler.OnPickUp != null)
                    DataHandler.OnPickUp();
                    break;

                case TriggerType.Popup:
                    PopUpHandler popUp = FindObjectOfType<PopUpHandler>();
                    popUp.SetNewStorage(popUpStorage);
                    break;

                case TriggerType.GameFinish:
                    LevelCompleteEvent?.Invoke();                  
                    break;

                default:
                    return;
            }
        }
    }
}