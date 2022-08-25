using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Player player;
    private float timeInLevel;
    private float infectedDuration;



    void Awake()
    {
        player = GetComponent<Player>();
        timeInLevel = 0;
    }

    void Update()
    {
        if (player.IsInfected())
        {
            infectedDuration += Time.deltaTime;
        }
        timeInLevel += Time.deltaTime;
    }

    public float TimeInLevel()
    {
        return timeInLevel;
    }

    public float InfectedDuration()
    {
        return infectedDuration;
    }
}