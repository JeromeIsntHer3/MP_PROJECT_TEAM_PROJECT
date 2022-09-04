using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Persistant Data")]
public class PersistantData : ScriptableObject
{
    public float musicVolume;
    public float fxVolume;
    public float playerHealth;
    public float playerRecovery;
    public float playerInfection;
    public int playerCoins;

    public float defaultVolume;
    public float defaultRecovery;
    public float defaultInfection;
    public float defaultHealth;
    public int defaultCoins;
}