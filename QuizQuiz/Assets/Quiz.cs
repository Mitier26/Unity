using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerPrefab;

    private void Start()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i <answerPrefab.Length; i++)
        {
            TextMeshProUGUI buttonText = answerPrefab[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

        
    }
}
