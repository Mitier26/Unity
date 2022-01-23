using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;  //질문을 출력하는 것
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQustion;           //퀴즈의 정보를 가지고 있는 ScriptabelObject

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;     //선택지 4개
    int correctAnswerIndex;                         //정답의 인덱스
    bool hasAnswereEarly = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;    //기본 그림
    [SerializeField] Sprite correctAnswerSprite;    //정답 그림

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questions.Count;
        progressBar.value = 0;
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if (progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

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
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";

       
    }

    void DisplayQuestion()
    {
        questionText.text = currentQustion.GetQuestion();
        // ScriptableObject에서 문제의 정보를 가지고 와 출력

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQustion.GetAnswer(i);
            //각 버튼의 TextMeshPro 컴포넌트를 저장
            //각 버튼에 ScriptableObject의 선택지를 출력
        }
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == currentQustion.GetCorrectAnswerIndex())  //정답을 선택 했을 경우
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            correctAnswerIndex = currentQustion.GetCorrectAnswerIndex();
            string correctAnswer = currentQustion.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was \n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

    void GetNextQuestion()  // 버튼의 상태를 기본값으로 변경
    {
        if(questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
            progressBar.value++;
            scoreKeeper.IncrementQuestionSeen();
        }
        
    }

    // 랜덤한 문제를 가지고 오고 기존의 문제는 삭제한다.
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQustion = questions[index];

        if(questions.Contains(currentQustion))
        {
            questions.Remove(currentQustion); ;
        }

        questions.Remove(currentQustion);
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
