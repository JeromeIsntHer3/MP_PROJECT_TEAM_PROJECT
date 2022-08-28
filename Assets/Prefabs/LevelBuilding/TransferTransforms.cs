using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferTransforms : MonoBehaviour
{
    public Transform originalGround;
    public Transform newParent;
    public GameObject newPrefab;

    void Start()
    {
        for(int i = 0; i < originalGround.childCount; i++)
        {
            Transform newPos = originalGround.GetChild(i);
            GameObject temp = Instantiate(newPrefab, newPos.position ,Quaternion.identity);
            temp.transform.SetParent(newParent);
            Destroy(originalGround.GetChild(i).gameObject);
        }
    }
}