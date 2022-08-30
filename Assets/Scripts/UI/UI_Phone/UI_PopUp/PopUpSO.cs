using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pop-up",menuName = "Pop-up/Pop-up")]
public class PopUpSO : ScriptableObject
{
    public string headerText;
    [TextArea(5,20)]
    public string mainText;
}