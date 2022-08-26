using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum TypeOfStat { Health, Recovery, Infection }

public class Player : MonoBehaviour
{
    [Header("Default Values")]
    [SerializeField]private float currHealth;
    [SerializeField]private float currRecovery;
    [SerializeField]private float currInfection;
    [SerializeField]private float currInfectionRate;

    private float overTimeDamage;
    private float overTimeDuration;
    private TypeOfStat statToChange;

    [SerializeField]
    private GameObject barrier;

    public Image statusOverlay;

    void Start()
    {

    }

    void Update()
    {
        ChangeStatUpdate();
        Infection();
    }

    public void SetStat(TypeOfStat typeOfChange, float amount, float infectionRate = 0)
    {
        switch (typeOfChange)
        {
            case (TypeOfStat.Health):
                currHealth = amount;
                break;
            case (TypeOfStat.Recovery):
                currRecovery = amount;
                break;
            case (TypeOfStat.Infection):
                currInfection = amount;
                currInfectionRate = infectionRate;
                break;
        }
    }

    public float GetStat(TypeOfStat typeOfChange)
    {
        switch (typeOfChange)
        {
            case (TypeOfStat.Health):
                return currHealth;
            case (TypeOfStat.Recovery):
                return currRecovery;
            case (TypeOfStat.Infection):
                return currInfection;
            default:
                Debug.Log("No Stat Returned");
                return 0;
        }
    }


    public void ChangeStat (TypeOfStat changeType, float amount, bool overTime = false, float overTimeAmount = 0, float duration = 0)
    {
        statToChange = changeType;
        switch (statToChange)
        {
            case TypeOfStat.Health:
                currHealth += amount;
                break;
            case TypeOfStat.Recovery:
                currRecovery += amount;
                break;
            case TypeOfStat.Infection:
                currInfection += amount;
                break;
            default:
                break;
        }
        if (overTime)
        {
            overTimeDamage = overTimeAmount;
            overTimeDuration = duration;
        }
        StatClamps();
    }

    void ChangeStatUpdate()
    {
        if(overTimeDuration > 0)
        {
            overTimeDuration -= Time.deltaTime;
            switch (statToChange)
            {
                case TypeOfStat.Health:
                    currHealth += overTimeDamage * Time.deltaTime;
                    break;
                case TypeOfStat.Recovery:
                    currRecovery += overTimeDamage * Time.deltaTime;
                    break;
                case TypeOfStat.Infection:
                    currInfection += overTimeDamage * Time.deltaTime;
                    break;
                default:
                    break;
            }
        }
        StatClamps();
    }

    void StatClamps()
    {
        currHealth = Mathf.Clamp(currHealth, 0, 100);
        currRecovery = Mathf.Clamp(currRecovery, 0, 100);
        currInfection = Mathf.Clamp(currInfection, 0, 100);
    }

    void Infection()
    {
        currInfection += currInfectionRate * Time.deltaTime;
        currInfection = Mathf.Clamp(currInfection, 0, 100);
        statusOverlay.color = Color.Lerp(Color.black, new Color(181/255f,0,203/255f,255), currInfection / 100);

        if(currInfection >= 100)
        {
            ChangeStat(TypeOfStat.Health, 0, true, -1, 999);
        }
    }
}