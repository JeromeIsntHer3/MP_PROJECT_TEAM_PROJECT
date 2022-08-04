using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectBuffHolder : MonoBehaviour
{
    public Buff thisBuff;

    [SerializeField]
    GameObject[] buffs;
    int index;

    void Awake()
    {
        index = Random.Range(0, buffs.Length);
        Instantiate(buffs[index], this.transform);
    }
}