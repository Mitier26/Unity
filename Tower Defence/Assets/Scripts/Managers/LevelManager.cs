using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] int lives = 10;

    public int TotalLives { get; set; }
    public int CurrentWave { get; set; }

    private void Start() {
        TotalLives = lives;
        CurrentWave = 1;
    }

    void ReduceLives(Enemy enemy)
    {
        TotalLives--;
        if(TotalLives <= 0)
        {
            TotalLives = 0;
            // Game Over
        }
    }

    private void WaveCompleted()
    {
        CurrentWave++;
        AchievementManager.Instance.AddProgress("Waves10", 1);
        AchievementManager.Instance.AddProgress("Waves20", 1);
        AchievementManager.Instance.AddProgress("Waves50", 1);
        AchievementManager.Instance.AddProgress("Waves100", 1);
    }

    void OnEnable()
    {
        Enemy.OnEndReached += ReduceLives;
        Spawner.OnWaveCompleted += WaveCompleted;
    }

    void OnDisable()
    {
        Enemy.OnEndReached -= ReduceLives;
        Spawner.OnWaveCompleted -= WaveCompleted;
    }

}
