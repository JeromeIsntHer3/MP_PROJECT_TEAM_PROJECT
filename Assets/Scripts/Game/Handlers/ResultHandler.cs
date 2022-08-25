using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeInfectedText;
    [SerializeField] private TextMeshProUGUI recoveryText;
    [SerializeField] private TextMeshProUGUI timeTakenText;
    [SerializeField] private TextMeshProUGUI gradeText;

    public void SetupResult(string timeInfected, string recovery, string timeTaken)
    {
        timeInfectedText.text = timeInfected;
        recoveryText.text = recovery;
        timeTakenText.text = timeTaken;
    }
}