using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    int randomNum = 10;
    int inputNum = 0;
    int count = 0;

    [SerializeField] int minValue;
    [SerializeField] int maxValue;

    [SerializeField] InputField input;
    [SerializeField] Text text;
    [SerializeField] Text countText;
    [SerializeField] Text buttonText;

    void Start()
    {   
        ResetGame();
    }

    void ResetGame()
    {
        input.text = null;
        randomNum = Random.Range(minValue, maxValue);
        text.text = minValue + " 에서 " + maxValue + "사이의 값을 찾아라";
        count = 0;
    }
    public void OnButtonClick()
    {
        if(input.text == "")
        {
            text.text = "숫자를 입력해";
            return ;
        }
        inputNum = int.Parse(input.text);

        if(randomNum == inputNum)
        {
            text.text = "잘했어요!";
            buttonText.text = "다시 시작";
            count = 0;
        }
        else if(randomNum > inputNum)
        {
            text.text = inputNum + "은 작다";
        }
        else 
        {
            text.text = inputNum + "은 크다";
        }
        input.text = null;
        count++;
        countText.text = count.ToString();

    }
}
