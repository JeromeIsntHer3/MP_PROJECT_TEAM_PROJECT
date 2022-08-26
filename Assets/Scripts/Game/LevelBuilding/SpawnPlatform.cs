using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platforms;

    void Start()
    {
        if (platforms.Length == 0) return;
        int index = Random.Range(0, platforms.Length);
        GameObject platform = Instantiate(platforms[index],transform.GetChild(0));
        platform.transform.position = new Vector3(transform.position.x, transform.position.y);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}