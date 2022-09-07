using System;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerData", menuName = "GameData/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Serializable]
    public class InGamePlayerData
    {
        public float health;
        public float recovery;
        public float infection;
        public float infectionRate;
        public ConsumableStorageSO inventory;
    }

    [Serializable]
    public class DefaultPlayerData
    {
        public float d_health;
        public float d_recovery;
        public float d_infection;
    }

    public InGamePlayerData inGamePlayerData;
    public DefaultPlayerData defaultPlayerData;
}