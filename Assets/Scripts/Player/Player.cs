using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public enum TypeOfStat { Health, Recovery, Infection }

public class Player : MonoBehaviour
{
    //Main Values
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float missedEatingDamage;

    //Values to be Set
    private float overTimeDamage;
    private float overTimeDuration;
    private Vector3 currRespawnLocation;
    private TypeOfStat statToChange;

    [SerializeField] private Image statusOverlay;
    [SerializeField] private GameObject interactBox;


    void Update()
    {
        ChangeStatUpdate();
        Infection();
        EatOnTime();
        if(playerData.inGamePlayerData.health <= 0)
        {
            GameEvents.current.GameOver();
        }
        if(playerData.inGamePlayerData.recovery >= 100)
        {
            GameEvents.current.GameComplete();
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
                    playerData.inGamePlayerData.health += overTimeDamage * Time.deltaTime;
                    break;
                case TypeOfStat.Recovery:
                    playerData.inGamePlayerData.recovery += overTimeDamage * Time.deltaTime;
                    break;
                case TypeOfStat.Infection:
                    playerData.inGamePlayerData.infection += overTimeDamage * Time.deltaTime;
                    break;
                default:
                    break;
            }
        }
        StatClamps();
    }

    void StatClamps()
    {
        playerData.inGamePlayerData.health = Mathf.Clamp(playerData.inGamePlayerData.health, 0, 100);
        playerData.inGamePlayerData.recovery = Mathf.Clamp(playerData.inGamePlayerData.recovery, 0, 100);
        playerData.inGamePlayerData.infection = Mathf.Clamp(playerData.inGamePlayerData.infection, 0, 100);
    }

    void Infection()
    {
        playerData.inGamePlayerData.infection += playerData.inGamePlayerData.infectionRate * Time.deltaTime;
        playerData.inGamePlayerData.infection = Mathf.Clamp(playerData.inGamePlayerData.infection, 0, 100);
        statusOverlay.color = Color.Lerp(Color.black, new Color(181/255f,0,203/255f,255), playerData.inGamePlayerData.infection / 100);

        if(playerData.inGamePlayerData.infection >= 100)
        {
            playerData.inGamePlayerData.health -= Time.deltaTime;
        }
    }

    void EatOnTime()
    {
        if (!TimeHandler.instance.HasEatenPill() && TimeHandler.instance.TimeReset())
        {
            GameHandler.instance.PillsNotEaten();
            //GameHandler.instance.MissedPill();
            switch (TimeHandler.instance.Cycles())
            {
                case < 1:
                    break;
                case < 6:
                    ChangeStat(TypeOfStat.Health, -missedEatingDamage);
                    ChangeStat(TypeOfStat.Recovery, -missedEatingDamage);
                    break;
                case < 11:
                    ChangeStat(TypeOfStat.Health, -missedEatingDamage * 2);
                    ChangeStat(TypeOfStat.Recovery, -missedEatingDamage * 2);
                    break;
                case < 16:
                    ChangeStat(TypeOfStat.Health, -missedEatingDamage * 3);
                    ChangeStat(TypeOfStat.Recovery, -missedEatingDamage * 3);
                    break;
                default:
                    ChangeStat(TypeOfStat.Health, -missedEatingDamage * 4);
                    ChangeStat(TypeOfStat.Recovery, -missedEatingDamage * 4);
                    break;
            }
        }
    }

    public void SetStat(TypeOfStat typeOfChange, float amount)
    {
        switch (typeOfChange)
        {
            case (TypeOfStat.Health):
                playerData.inGamePlayerData.health = amount;
                break;
            case (TypeOfStat.Recovery):
                playerData.inGamePlayerData.recovery = amount;
                break;
            case (TypeOfStat.Infection):
                playerData.inGamePlayerData.infection = amount;
                break;
        }
    }

    public float GetStat(TypeOfStat typeOfChange)
    {
        switch (typeOfChange)
        {
            case (TypeOfStat.Health):
                return playerData.inGamePlayerData.health;
            case (TypeOfStat.Recovery):
                return playerData.inGamePlayerData.recovery;
            case (TypeOfStat.Infection):
                return playerData.inGamePlayerData.infection;
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
                playerData.inGamePlayerData.health += amount;
                break;
            case TypeOfStat.Recovery:
                playerData.inGamePlayerData.recovery += amount;
                break;
            case TypeOfStat.Infection:
                playerData.inGamePlayerData.infection += amount;
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

    public void Respawn()
    {
        transform.position = currRespawnLocation;
    }

    public void SetRespawnLocation(Vector3 location)
    {
        currRespawnLocation = location;
    }

    public void SetInteractBox(bool set)
    {
        interactBox.SetActive(set);
    }
}