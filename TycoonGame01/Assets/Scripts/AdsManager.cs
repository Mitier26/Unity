using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    // 유니티 데쉬보드에서 확인 할 수 있는 아이디
    [SerializeField] string androidID = "4618999";

    // 만든 광고의 이름
    [SerializeField] string doubleMoneyVideoPlacementId = "doubleMoneyVideo";
    [SerializeField] string skippableVideoPlacementId = "SkippableVideo";

    void Start()
    {
        // 광고를 사용하기 위해 해야하는것
        Advertisement.AddListener(this);
        // 광고의 ID를 세팅
        Advertisement.Initialize(androidID);
    }

    // 리워드 광고를 보여주는 것
    public void ShowDoubleMoneyAd()
    {
        Advertisement.Show(doubleMoneyVideoPlacementId);
    }

    // 스킵가능한 광고를 보여주는 것
    public void ShowSkippableAd()
    {
        Advertisement.Show(skippableVideoPlacementId);
    }

    // 광고에 에러가 있을 때
    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    // 광고가 종료되었을 때
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // 매개변수로 있는 결과가 Finished 라면
        // File 도 있다.
        if(showResult == ShowResult.Finished)
        {
            // 광고의 종류가 보상형 광고라면
            if(placementId == doubleMoneyVideoPlacementId)
            {
                Debug.Log("돈 2 배");
                // 지금 있는 돈에서 지금 있는 돈을 더 한다.
                MoneyManager.instance.AddMoney(MoneyManager.instance.Money);
            }
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    // 광고가 준비되었을 때
    public void OnUnityAdsReady(string placementId)
    {
        throw new System.NotImplementedException();
    }

}
