using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("점수")]
    int score;
    int highScore;
    public Text scoreText;
    public Text highScoreText;

    [Header("게임오버")]
    public GameObject gameOverPanel;

    void Start()
    {
        GetHighScore();
    }
    
    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "Best : " + highScore;
    }

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text ="Best : " + score;
        }
    }

    public void OnBombHit()
    {
        // 게임 정지
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);

    }
}
