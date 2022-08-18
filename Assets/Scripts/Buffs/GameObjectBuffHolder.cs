using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectBuffHolder : MonoBehaviour
{
    public Buff thisBuff;

    [SerializeField]
    GameObject[] buffs;

    void Awake()
    {
        Destroy(GetComponent<MeshRenderer>());
        if (buffs.Length == 0) return;
        int index = Random.Range(0, buffs.Length);
        Instantiate(buffs[index], this.transform);
    }
}