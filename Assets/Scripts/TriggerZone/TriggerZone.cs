using UnityEngine;
using System.Collections;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private TriggerZoneData thisTrigger;

    public static bool GameOver;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            thisTrigger.TriggerZoneFunction();
        }


        //HealthInterfaces otherObj  = other.GetComponent<HealthInterfaces>();

        //if (typeOfBox == Type.damage) otherObj.Damage(healAndDamageAmount);
        //if (typeOfBox == Type.heal) otherObj.Heal(healAndDamageAmount);
        //if (typeOfBox == Type.death)
        //{
        //    if (other.gameObject != null) Destroy(other.gameObject);
        //    if (other.tag == "Player")
        //    {
        //        SoundManager.Instance.PlaySound(SoundManager.Instance.DieSound);
        //        GameOver = true;
        //    }
        //}
        //if(typeOfBox == Type.popup && other.tag == "Player")
        //{
        //    popUpHandler.SetUpPopUp(popUp);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoundManager sm = FindObjectOfType<SoundManager>();
            sm.PlaySound(sm.DieSound);
            thisTrigger.TriggerZoneFunction();
        }
    }
}