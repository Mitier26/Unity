using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;

[Serializable]
public class BuildingData
{
    [SerializeField] public bool IsUnlocked {get; set;}

    [SerializeField] public int BuildingLvl {get; set;}

    [SerializeField] public string Profit {get; set;}

    // 생성자를 이용한다.
    // 객체를 만들어서 저장 하는 방법
    public BuildingData(bool isUnlocked, int buildingLvl, string profit)
    {
        this.IsUnlocked = isUnlocked;
        this.BuildingLvl = buildingLvl;
        this.Profit = profit;
    }

    // 빌딩의 정보를 넣으면 Json 파일로 변경
    public static string CreateJSONFromBuilding(BuildingData building)
    {
        return JsonConvert.SerializeObject(building);
    }

    // Json 파일을 받아서 빌딩의 정도를 받는다.
    public static BuildingData CreateBuildingFromJSON(string jsonString)
    {
        return JsonConvert.DeserializeObject<BuildingData>(jsonString);
    }
}
