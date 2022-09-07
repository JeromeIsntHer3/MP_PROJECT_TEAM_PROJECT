using System;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerData", menuName = "GameData/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Serializable]
    public class InGamePlayerData
    {
        [Header("Attributes")]
        public float health;
        public float recovery;
        public float infection;
        public float infectionRate;
        [Header("Score & Collectables")]
        public ConsumableStorageSO inventory;
        public int currency;
        public int pillsNotEaten;
        public float timePlayed;
        public int questionsCorrect;
    }

    [Serializable]
    public class DefaultPlayerData
    {
        public float d_health;
        public float d_recovery;
        public float d_infection;
        public float d_infectionRate;
        public int d_currency;
        public int d_pillsNotEaten;
        public float d_timePlayed;
        public int d_questionsCorrect;
    }

    public InGamePlayerData inGamePlayerData;
    public DefaultPlayerData defaultPlayerData;
}