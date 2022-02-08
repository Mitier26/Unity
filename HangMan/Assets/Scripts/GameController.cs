using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour
{
    public GameObject[] hangMan;
    [SerializeField] Text timeText;
    [SerializeField] Text findWord;
    [SerializeField] GameObject replayBtn;

    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;

    [SerializeField] float gameTime;
    string[] wordsLocal = {"MILK", "POTATO", "MITIER", "SUPER"};
    string[] words = File.ReadAllLines(@"Assets/Words.txt");
    string[] node;
    string chosenWord;
    string hiddenWord;
    int fails = 0;

    bool gameEnd = false;

    void Start()
    {
        gameTime = 0;
        
        chosenWord = words[Random.Range(0, words.Length)];

        for(int i = 0 ; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];

            if(char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "_";
            }

        }

        findWord.text = hiddenWord;
    }

    void Update()
    {
        if(!gameEnd)
        {
            gameTime += Time.deltaTime;
            timeText.text = gameTime.ToString("0");
        }
        
    }

    void OnGUI()
    {
        Event e = Event.current;
        if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string pressedKey = e.keyCode.ToString();

            if(chosenWord.Contains(pressedKey))
            {
                int index = chosenWord.IndexOf(pressedKey);

                while(index != -1)
                {
                    hiddenWord = hiddenWord.Substring(0,index) + pressedKey + hiddenWord.Substring(index + 1);

                    chosenWord = chosenWord.Substring(0,index) + "_" + chosenWord.Substring(index + 1);

                    index = chosenWord.IndexOf(pressedKey);
                }

                findWord.text = hiddenWord;
            }
            else
            {
                hangMan[fails].SetActive(true);
                fails++;
            }
        }

        if(fails == hangMan.Length)
        {
            loseText.SetActive(true);
            replayBtn.SetActive(true);
            gameEnd = true;
        }

        if(!hiddenWord.Contains("_"))
        {
            winText.SetActive(true);
            replayBtn.SetActive(true);
            gameEnd = true;
        }
    }
}
