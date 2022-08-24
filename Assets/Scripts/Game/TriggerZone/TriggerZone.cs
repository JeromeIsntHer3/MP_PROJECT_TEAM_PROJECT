using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
    public enum TriggerType
    {
        Die,PopUp,Notification,GameFinish
    }

    public TriggerType triggerType;

    private Player player;
    private MenusHandler uIHandler;

    [Header("PopUp")]
    public Vector3 popUpPosition;
    public Vector3 popUpSize;
    [Multiline]
    public string textToShow;
    public bool seen = false;

    [Header("Notification")]
    public NotificationData notificationData;
    public ThisApp sendToApp;

    public static bool GameOver, LevelComplete;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        uIHandler = FindObjectOfType<MenusHandler>();
        GameOver = LevelComplete = false;
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
                        GameOver = true;
                    }
                    break;

                case TriggerType.Notification:
                    sendToApp.AddNotification(notificationData);
                    if(DataHandler.OnPickUp != null)
                    DataHandler.OnPickUp();
                    break;

                case TriggerType.PopUp:
                    if (seen) return;
                    PopUp popUp = FindObjectOfType<PopUp>();
                    popUp.SetUpPopUp(popUpPosition, popUpSize, textToShow);
                    //seen = true;
                    break;

                case TriggerType.GameFinish:
                    LevelComplete = true;                    
                    break;

                default:
                    return;
            }
        }
    }
}