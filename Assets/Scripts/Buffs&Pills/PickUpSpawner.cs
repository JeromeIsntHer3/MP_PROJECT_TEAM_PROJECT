using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private bool respawn;
    [SerializeField] GameObject[] prefabs;

    private float timerCountdown;

    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    void Start()
    {
        if (!respawn)
        {
            Spawn();
        }
    }

    void Update()
    {
        if(CountdownOver() && !Spawned() && respawn)
        {
            Spawn();
        }
    }

    bool CountdownOver()
    {
        if(timerCountdown > 0)
        {
            timerCountdown -= Time.deltaTime;
            return false;
        }
        else
        {
            timerCountdown = spawnTimer;
            return true;
        }
    }

    bool Spawned()
    {
        return transform.childCount > 0;
    }

    void Spawn()
    {
        if (prefabs.Length == 0) return;
        int index = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[index], this.transform);
    }
}