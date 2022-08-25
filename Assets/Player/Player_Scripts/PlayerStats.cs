using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Player player;
    private float timeInLevel;
    public string GetTimeInLevel()
    {
        return timeInLevel.ToString();
    }

    private float infectedDuration;
    public string GetInfectedDuration()
    {
        return infectedDuration.ToString();
    }



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
}