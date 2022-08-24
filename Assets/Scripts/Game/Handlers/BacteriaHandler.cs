using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaHandler : MonoBehaviour
{

    public static BacteriaHandler instance;

    [SerializeField]
    private GameObject[] bacteria;
    [SerializeField]
    private float spawnAgainTime;
    [SerializeField]
    private float xLength;
    [SerializeField]
    private float yLength;

    [SerializeField]
    private Transform spawnSpot;
    private float timeToSpawn;
    private bool toSpawn;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (timeToSpawn > 0)
        {
            timeToSpawn -= Time.deltaTime;
        }
        else
        {
            toSpawn = true;
        }
    }

    public void SpawnBacteria(int numberOfSpawns)
    {
        if (toSpawn)
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                int index = Random.Range(0, bacteria.Length);
                spawnSpot.position = new Vector2(Random.Range(0,25),Random.Range(-14,14));
                spawnSpot.position = new Vector2(Random.Range(gameObject.transform.position.x - xLength, gameObject.transform.position.x + xLength),
                    Random.Range(gameObject.transform.position.y - yLength, gameObject.transform.position.y + yLength));
                Instantiate(bacteria[index], spawnSpot.position, spawnSpot.rotation, transform);
            }
            toSpawn = false;
            timeToSpawn = spawnAgainTime;
        }
    }

    public int BacteriaCount()
    {
        int b = transform.childCount;
        return b;
    }
}