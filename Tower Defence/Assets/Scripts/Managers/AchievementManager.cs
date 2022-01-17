using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AchievementManager : Singleton<AchievementManager>
{
    public static Action<Achievement> OnAchievementUnlocked;
    public static Action<Achievement> OnProgressUpdated;

    [SerializeField] private AchievementCard achievementCardPrefab;
    [SerializeField] private Transform achievementPanelContainer;
    [SerializeField] private Achievement[] achievements;

    void Start()
    {
        LoadAchievements();
    }

    private void LoadAchievements()
    {
        for(int i = 0; i < achievements.Length; i++)
        {
            AchievementCard card = Instantiate(achievementCardPrefab, achievementPanelContainer);
            card.SetupAchivement(achievements[i]);
        }
    }

    public void AddProgress(string achievementID, int amount)
    {
        Achievement achievementWanted = AchievementExists(achievementID);
        if(achievementWanted != null)
        {
            achievementWanted.AddProgress(amount);
        }
    }

    private Achievement AchievementExists(string achievementID)
    {
        for(int i = 0 ; i < achievements.Length; i++)
        {
            if(achievements[i].ID == achievementID)
            {
                return achievements[i];
            }
        }
        return null;
    }
}
