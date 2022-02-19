using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitCollector : MonoBehaviour
{
    [SerializeField] float profitCollectionInterval = 5f;

    [SerializeField] GameObject dogAvatar;

    float profitCollectionTimer = 0;
    List<Building> buildings;

    int isManagerHired = 0;

    void Start()
    {
        isManagerHired = PlayerPrefs.GetInt("isManagerHired", 0);

        dogAvatar.SetActive(isManagerHired == 1 ? true : false);

        buildings = new List<Building>();

        buildings.AddRange(GameObject.FindObjectsOfType<Building>());
    }

    void Update()
    {
        if(isManagerHired == 1)
        {
            profitCollectionTimer += Time.deltaTime;

            if(profitCollectionTimer >= profitCollectionInterval)
            {
                profitCollectionTimer = 0;

                foreach(Building building in buildings)
                {
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
