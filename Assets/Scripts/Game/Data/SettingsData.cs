using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsData", menuName = "GameData/SettingsData")]
public class SettingsData : ScriptableObject
{
    [Serializable]
    public class InGameSettingsData
    {
        public float musicVolume;
        public float effectsVolume;
    }

    [Serializable]
    public class DefaultSettingsData
    {
        public float d_musicVolume;
        public float d_effectsVolume;
    }

    public InGameSettingsData inGameSettingsData;
    public DefaultSettingsData defaultSettingsData;
}