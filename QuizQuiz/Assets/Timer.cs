using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;    //퀴즈를 풀때 타이머
    [SerializeField] float timeToShowCorrectAnswer = 10f;   //답을 확인 할 때 타이머

    public bool loadNextQuestion;   //답의 확인이 끝나면 다름 문제를 풀기위한 것
    public float fillFraction;      //동그라미의 채워 지는 량

    public bool isAnsweringQuestion;    //답을 선택 중 인지
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();  //계속 실행
    }

    public void CancleTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;   // 시간을 지속적으로 감소

        if(isAnsweringQuestion)     //답을 선택하고 있다면
        {
            if(timerValue > 0)  //시간값이 0 보다 크다면
            {
                fillFraction = timerValue / timeToCompleteQuestion; //동그라미를 감소 시킨다.
            }
            else// 시간 값이 0 보다 작다면
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
                // 정답선택 중을 정지하고 시간 값을 정답 확인 시간으로 변경
            }
        }
        else// 답을 확인 중
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
    }
}
