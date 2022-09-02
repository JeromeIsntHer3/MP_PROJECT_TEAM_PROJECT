using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu (fileName = "LevelSO",menuName = "Level/LevelSO")]
public class LevelSO : ScriptableObject
{
    public int levelNumber;
    public bool unlocked;
}