using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QustionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "여기에 문제를 입력 하세요";
    [SerializeField] string[] answers = new string[4];
    [Range(1,4)]
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

}
