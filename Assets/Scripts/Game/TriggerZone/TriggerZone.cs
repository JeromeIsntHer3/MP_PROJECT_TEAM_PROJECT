using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
    public enum TriggerType
    {
        Heal,Damage,Die,PopUp,Notification
    }

    public TriggerType tt;

    private Player player;

    [Header("Heal")]
    public float healAmount;

    [Header("Damage")]
    public float damageAmount;

    [Header("PopUp")]
    public Vector3 popUpSize;
    public Vector3 popUpPosition;
    [Multiline]
    public string textToShow;
    public bool seen = false;

    [Header("Notification")]
    public NotificationData notificationData;
    public enum WhichApp
    {
        Net,Message,Med,Info
    }
    public WhichApp app;
    public AppDisplay display;

    public static bool GameOver;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (tt)
            {
                case TriggerType.Heal:
                    player.Heal(healAmount);
                    break;

                case TriggerType.Die:
                    SoundManager sm = FindObjectOfType<SoundManager>();
                    sm.PlaySound(sm.DieSound);
                    if (player)
                    {
                        Destroy(player.gameObject);
                        TriggerZone.GameOver = true;
                    }
                    break;

                case TriggerType.Damage:
                    player.Damage(damageAmount);
                    break;

                case TriggerType.Notification:
                    switch (app)
                    {
                        case WhichApp.Net:
                            display.AddNotification(1,notificationData);
                            break;
                        case WhichApp.Message:
                            display.AddNotification(2, notificationData);
                            break;
                        case WhichApp.Med:
                            display.AddNotification(3, notificationData);
                            break;
                        case WhichApp.Info:
                            display.AddNotification(4, notificationData);
                            break;
                        default:
                            return;
                    }
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