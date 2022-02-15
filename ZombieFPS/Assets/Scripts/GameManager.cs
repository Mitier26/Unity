using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;    // 살아있는 좀비의 수

    public int round = 0;   // 진행한 판수

    public GameObject[] spawnPoints;    // 소환 위치

    public GameObject enemyPrefab;

    public Text roundNumber;
    public Text roundSurvived;
    public GameObject endScreen;

    void Update()
    {
        if(enemiesAlive == 0)
        {
            // 좀비가 0 마리가 되면 라운드를 증사 시킨다.
            round++;
            NextWave(round);
            roundNumber.text = "Round : " + round.ToString();
        }
    }

    public void NextWave(int round)
    {
        // 다음 라운드를 시작하는 것
        for(var x = 0; x< round; x++)
        {
            // 라운드의 수에 따라 좀비를 등장시킨다.
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject eneySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            eneySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>();
            // 생성한 좀비에 바로 GameManager를 준다.
            enemiesAlive++;
        }

    }

    public void EndGame()
    {
        Time.timeScale = 0;
        roundSurvived.text = round.ToString();
        Cursor.lockState = CursorLockMode.None; // 마우스를 일반 마우스 상태로
        endScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
