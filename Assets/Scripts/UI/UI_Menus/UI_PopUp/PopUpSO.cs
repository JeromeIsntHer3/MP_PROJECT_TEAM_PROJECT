using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pop-up",menuName = "Pop-up/Pop-up")]
public class PopUpSO : ScriptableObject
{
    public string header;
    [Multiline]
    public string main;
}