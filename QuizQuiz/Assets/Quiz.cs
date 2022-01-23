using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;  //질문을 출력하는 것
    [SerializeField] QuestionSO question;           //퀴즈의 정보를 가지고 있는 ScriptabelObject

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;     //선택지 4개
    int correctAnswerIndex;                         //정답의 인덱스
    bool hasAnswereEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;    //기본 그림
    [SerializeField] Sprite correctAnswerSprite;    //정답 그림

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        DisplayQuestion();

    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            hasAnswereEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnswereEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index) // 버튼 클릭에 사용할 것
    {
        hasAnswereEarly = true;
        DisplayAnswer(index);

        SetButtonState(false);
        timer.CancleTimer();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        // ScriptableObject에서 문제의 정보를 가지고 와 출력

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
            //각 버튼의 TextMeshPro 컴포넌트를 저장
            //각 버튼에 ScriptableObject의 선택지를 출력
        }
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())  //정답을 선택 했을 경우
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was \n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion()  // 버튼의 상태를 기본값으로 변경
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length;i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
