using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public enum TypeOfStat { Health, Recovery, Infection }

public class Player : MonoBehaviour
{
    //Main Values
    private float currHealth;
    private float currRecovery;
    private float currInfection;
    private float currInfectionRate;

    //Values to be Set
    private float overTimeDamage;
    private float overTimeDuration;
    private Vector3 currRespawnLocation;
    private TypeOfStat statToChange;

    [SerializeField] private ParticleSystem psystem;
    [SerializeField] private GameObject avatar;
    [SerializeField] private GameObject particle;
    [SerializeField] private Image statusOverlay;
    [SerializeField] private GameObject interactBox;

    void Update()
    {
        ChangeStatUpdate();
        Infection();
        EatOnTime();
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
        TypeOfStat stat;
        stat = changeType;
        switch (stat)
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
            currHealth -= Time.deltaTime;
        }
    }

    void EatOnTime()
    {
        if (!TimeHandler.instance.HasEatenPill() && TimeHandler.instance.TimeReset())
        {
            switch (TimeHandler.instance.Cycles())
            {
                case < 1:
                    break;
                case < 6:
                    ChangeStat(TypeOfStat.Health, -5);
                    ChangeStat(TypeOfStat.Recovery, -5);
                    break;
                case < 11:
                    ChangeStat(TypeOfStat.Health, -10);
                    ChangeStat(TypeOfStat.Recovery, -10);
                    break;
                case < 16:
                    ChangeStat(TypeOfStat.Health, -15);
                    ChangeStat(TypeOfStat.Recovery, -15);
                    break;
                default:
                    ChangeStat(TypeOfStat.Health, -20);
                    ChangeStat(TypeOfStat.Recovery, -20);
                    break;
            }
        }
    }

    public void SetRespawnLocation(Vector3 location)
    {
        currRespawnLocation = location;
    }

    public void Respawn()
    {
        transform.position = currRespawnLocation;
    }

    public void SetInteractBox(bool set)
    {
        interactBox.SetActive(set);
    }

    public void Die()
    {
        PlayerMovement pm = GetComponent<PlayerMovement>();
        pm.rb.isKinematic = true;
        avatar.SetActive(false);
        particle.SetActive(true);
        psystem.Play();
        psystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}