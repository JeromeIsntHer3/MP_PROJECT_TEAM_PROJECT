using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    public float spawnTimer;

    [SerializeField]
    GameObject[] buffPrefabs;

    private float timerCountdown;

    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Update()
    {
        if (!BuffSpawned())
        {
            Countdown();
        }
        else
        {
            timerCountdown = spawnTimer;
        }
    }

    void Countdown()
    {
        if(timerCountdown > 0)
        {
            timerCountdown -= Time.deltaTime;
        }
        else
        {
            Spawn();
        }
    }

    void Spawn()
    {
        if (buffPrefabs.Length == 0) return;
        int index = Random.Range(0, buffPrefabs.Length);
        Instantiate(buffPrefabs[index], this.transform);
    }

    bool BuffSpawned()
    {
        return transform.childCount > 0;
    }
}