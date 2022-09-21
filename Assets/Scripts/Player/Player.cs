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
    private Vector3 currRespawnLocation;



    void Update()
    {
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

    void StatClamps()
    {
        playerData.inGamePlayerData.health = Mathf.Clamp(playerData.inGamePlayerData.health, 0, 100);
        playerData.inGamePlayerData.recovery = Mathf.Clamp(playerData.inGamePlayerData.recovery, 0, 100);
        playerData.inGamePlayerData.infection = Mathf.Clamp(playerData.inGamePlayerData.infection, 0, 100);
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

    public void ChangeStat (TypeOfStat changeType, float amount)
    {
        switch (changeType)
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
}