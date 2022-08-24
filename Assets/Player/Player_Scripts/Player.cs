using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public enum TypeOfStat { Health, Recovery, Infection }

public class Player : MonoBehaviour
{
    [Header("Default Values")]
    [SerializeField]
    private float baseInfectionRate = 0;
    [SerializeField]
    private bool infected;

    //Values To Be Set
    public float currHealth;
    private float currRecovery;
    private float currInfection;
    private float currInfectionRate;

    private float overTimeDamage;
    private float overTimeDuration;
    private TypeOfStat statToChange;

    public void SetStat(TypeOfStat typeOfChange, float amount)
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

    [SerializeField]
    private GameObject barrier;

    public Image statusOverlay;

    private BacteriaHandler bacteriaHandler;

    void Start()
    {
        bacteriaHandler = BacteriaHandler.instance;

        currInfectionRate = baseInfectionRate;
    }

    void Update()
    {
        Infection();
        ChangeStatUpdate();
    }

    void FixedUpdate()
    {
        StatClamps();
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
    }

    void StatClamps()
    {
        currHealth = Mathf.Clamp(currHealth, 0, 100);
        currRecovery = Mathf.Clamp(currRecovery, 0, 100);
        currInfection = Mathf.Clamp(currInfection, 0, 100);
    }

    public void EnableBarrier()
    {
        barrier.SetActive(true);
    }

    public void DisableBarrier()
    {
        barrier.SetActive(false);
    }

    void Infection()
    {
        if (infected) 
        {
            currInfection += currInfectionRate * Time.deltaTime;
        }
        else
        {
            currInfection -= currInfectionRate * Time.deltaTime;
        }
        currInfection = Mathf.Clamp(currInfection, 0, 100);
        statusOverlay.color = Color.Lerp(Color.black, Color.magenta, currInfection / 100);

        if (currInfection >= 100)
        {
            if (bacteriaHandler.BacteriaCount() > 25) { return; }
            bacteriaHandler.SpawnBacteria(bacteriaHandler.BacteriaCount());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Infected")
        {
            infected = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Infected")
        {
            infected = false;
        }
    }
}