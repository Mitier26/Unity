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
            // 점수가 최고 점수 보다 높으면 저장
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
        // 시간의 흐름을 다시 정상으로 만들어 야 한다.
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);

    }
}
