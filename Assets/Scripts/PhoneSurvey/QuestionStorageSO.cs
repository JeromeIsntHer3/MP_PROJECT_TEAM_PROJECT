using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question&AnswersStorage", menuName = "Question&Answers/Storage")]
public class QuestionStorageSO : ScriptableObject
{
    public List<QuestionSO> Questions;
}