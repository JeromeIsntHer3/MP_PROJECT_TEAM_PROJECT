using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefabs;

    void Start()
    {
        if (platformPrefabs.Length == 0) return;
        int index = Random.Range(0, platformPrefabs.Length);
        GameObject platform = Instantiate(platformPrefabs[index],transform.GetChild(0));
        platform.transform.position = new Vector3(transform.position.x, transform.position.y);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}