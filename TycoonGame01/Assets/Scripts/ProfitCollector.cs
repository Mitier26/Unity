using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitCollector : MonoBehaviour
{
    // 돈 수집 간격
    [SerializeField] float profitCollectionInterval = 5f;
    // 화면에 보여질 것
    [SerializeField] GameObject dogAvatar;
    // 수집 경과 시간
    float profitCollectionTimer = 0;
    // 각 빌딩
    List<Building> buildings;
    // bool 처럼 사용
    int isManagerHired = 0;

    void Start()
    {
        // 매니저가 고용되었는지 저장된 값을 불러온다.
        isManagerHired = PlayerPrefs.GetInt("isManagerHired", 0);
        // 매니저가 고용되었다면 오브젝트를 활성화 한다.
        dogAvatar.SetActive(isManagerHired == 1 ? true : false);

        buildings = new List<Building>();
        // 빌딩들을 찾아서 한번에 넣는다.
        buildings.AddRange(GameObject.FindObjectsOfType<Building>());
    }

    void Update()
    {
        //매니저가 고용되었다면
        if(isManagerHired == 1)
        {
            // 경과 시간을 증가
            profitCollectionTimer += Time.deltaTime;

            if(profitCollectionTimer >= profitCollectionInterval)
            {
                profitCollectionTimer = 0;

                // 빌딩 리스트에 있는 빌딩의
                foreach(Building building in buildings)
                {
                    // 수입회수 버튼을 누른것 같은 효과
                    // 수입을 회수
                    building.OnCollectProfitButton();
                }
            }
        }
    }

    public void HireManager()
    {
        isManagerHired = 1;
        dogAvatar.SetActive(true);
        PlayerPrefs.SetInt("isManagerHired", isManagerHired);
    }
}
