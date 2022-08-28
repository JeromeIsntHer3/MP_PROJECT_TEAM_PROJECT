using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;

public class TriggerZone : MonoBehaviour
{
    public enum TriggerType
    {
        RespawnPoint, Respawn, Die, Notification, GameFinish, Popup, Bacterial, Viral
    }

    public TriggerType triggerType;

    private Player player;

    [Header("Pop-up")]
    public PopUpStorage popUpStorage;

    [Header("Notification")]
    public NotificationData notificationData;
    public ThisApp sendToApp;

    [Header("Bacterial")]
    public float infectionIncrease;
    public float infectionRateIncrease;

    [Header("Viral")]
    public float recoveryDecreaseRate;
    public float recoveryDecreaseDuration;

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

                case TriggerType.Bacterial:
                    player.SetStat(TypeOfStat.Infection,0,infectionRateIncrease);
                    player.ChangeStat(TypeOfStat.Infection, infectionIncrease);
                    break;

                case TriggerType.Viral:
                    player.ChangeStat(TypeOfStat.Recovery, 0, true, recoveryDecreaseRate, recoveryDecreaseDuration);
                    player.SetViral(true);
                    break;

                case TriggerType.RespawnPoint:
                    player.SetRespawnLocation(transform.position);
                    break;

                case TriggerType.Respawn:
                    player.Respawn();
                    break;
                default:
                    return;
            }
        }
    }
}