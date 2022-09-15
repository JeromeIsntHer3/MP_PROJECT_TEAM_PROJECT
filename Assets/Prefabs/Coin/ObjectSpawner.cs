using UnityEngine;
using System.Collections.Generic;


public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<Transform> childTransforms;
    [SerializeField] private float spawnTime;


    void Awake()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            childTransforms.Add(transform.GetChild(i).transform);
        }
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    void Spawn()
    {
        if (childTransforms.Count == 0) return;
        int index = Random.Range(0, childTransforms.Count);
        if (childTransforms[index].transform.childCount > 0)
        {
            index++;
            return;
        }
        GameObject temp = Instantiate(prefab, childTransforms[index]);
        Coin coin = temp.GetComponent<Coin>();
        if (coin)
        {
            coin.currencyValue = Random.Range(1, 5);
        }
    }
}