using UnityEngine;
using System.Collections.Generic;


public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Transform> transforms;


    void Awake()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            transforms.Add(transform.GetChild(i).transform);
        }
        InvokeRepeating("Spawn", 5, 5);
    }

    void Spawn()
    {
        if (transforms.Count == 0) return;
        int index = Random.Range(0, transforms.Count);
        if (transforms[index].transform.childCount > 0) return;
        Instantiate(prefab, transforms[index]);
    }
}