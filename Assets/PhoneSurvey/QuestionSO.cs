using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Question&Answers", menuName = "Question&Answers/Questions")]
public class QuestionSO : ScriptableObject
{
    [TextArea] public string question;
    [TextArea] public List<string> options;
    public List<bool> correctOrWrong;
    public bool answered;
}