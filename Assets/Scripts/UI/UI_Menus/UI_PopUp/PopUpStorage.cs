using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pop-up", menuName = "Pop-up/Pop-up Storage")]
public class PopUpStorage : ScriptableObject
{
    public List<PopUpSO> popUps;
}