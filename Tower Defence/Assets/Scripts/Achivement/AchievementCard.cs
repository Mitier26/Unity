using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementCard : MonoBehaviour
{
    [SerializeField] private Image achievementImage;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI progress;
    [SerializeField] private TextMeshProUGUI reward;

    public Achievement AchievementLoaded { get; set; }

    public void SetupAchivement(Achievement achievement)
    {
        AchievementLoaded = achievement;
        achievementImage.sprite = achievement.Spretie;
        title.text = achievement.Title;
        progress.text = achievement.GetProgress();
        reward.text = achievement.GoldReward.ToString();
    }

    private void UpdateProgress(Achievement achievementWithProgress)
    {
        if(AchievementLoaded == achievementWithProgress)
        {
            progress.text = achievementWithProgress.GetProgress();
        }
    }

    void OnEnable()
    {
        AchievementManager.OnProgressUpdated += UpdateProgress;
    }

    void OnDisable()
    {
        AchievementManager.OnProgressUpdated -= UpdateProgress;
    }

}
