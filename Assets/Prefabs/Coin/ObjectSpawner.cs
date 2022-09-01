using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject prefab;


    void Awake()
    {
        InvokeRepeating("Spawn", 5, 5);
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0) return;
        int index = Random.Range(0, spawnPoints.Length-1);
        Instantiate(prefab, spawnPoints[index]);
    }
}