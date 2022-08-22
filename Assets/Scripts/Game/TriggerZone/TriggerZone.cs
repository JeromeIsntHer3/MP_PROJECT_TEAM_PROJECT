using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
    public enum TriggerType
    {
        Die,PopUp,Notification
    }

    public TriggerType triggerType;

    private Player player;

    [Header("PopUp")]
    public Vector3 popUpPosition;
    public Vector3 popUpSize;
    [Multiline]
    public string textToShow;
    public bool seen = false;

    [Header("Notification")]
    public NotificationData notificationData;
    public ThisApp sendToApp;

    public static bool GameOver;

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
                        TriggerZone.GameOver = true;
                    }
                    break;

                case TriggerType.Notification:
                    sendToApp.AddNotification(notificationData);
                    if(GameHandler.OnPickUp != null)
                    GameHandler.OnPickUp();
                    break;

                case TriggerType.PopUp:
                    if (seen) return;
                    PopUp popUp = FindObjectOfType<PopUp>();
                    popUp.SetUpPopUp(popUpPosition, popUpSize, textToShow);
                    //seen = true;
                    break;

                default:
                    return;
            }
        }
    }
}