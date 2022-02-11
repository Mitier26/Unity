using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public Text scoreText;
    public Text highScoreText;

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();
    }
}
