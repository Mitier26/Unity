using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 팝업 메뉴에 보여지는 것
// 팝업 메뉴에 QuizQuestion 이라고 보이고
// 파일을 만들면 New Question 이라고 생성된다.
[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QuestionSO : ScriptableObject   // MonoBehaviour 가 아니다
{
    [TextArea(2,6)] // 글을 입력하는 곳이 1줄이 아니고 6줄이 된다.
    [SerializeField] string question = "여기에 문제를 입력 하세요";
    [SerializeField] string[] answers = new string[4];
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
