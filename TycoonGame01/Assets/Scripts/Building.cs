using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class Building : MonoBehaviour
{
    // 건물 아이디
    [SerializeField] int id;
    [SerializeField] GameObject buildingVisuals;
    [SerializeField] GameObject buyButton;
    [SerializeField] string costRepresentation;

    [SerializeField] GameObject collectProfitButton;

    Text collectProfitButtonText;

    [SerializeField] int buildingLvl = 1;
    [SerializeField] int profitMultiplier = 1;
    [SerializeField] BigInteger profit;

    // 업그레이드에 관한것
    [SerializeField] int upgradeCostMultiplier = 10;

    BigInteger NextUpgradeCost
    {
        get
        {
            return buildingLvl * upgradeCostMultiplier;
        }
    }

    [SerializeField] GameObject upgradeButton;
    Text upgradeButtonText ;
    
    public BigInteger Cost
    {
        get{return BigInteger.Parse(costRepresentation);}
        set{costRepresentation = value.ToString();}
    }

    bool isUnlocked = false;

    Text buyButtonText;

    void Start()
    {
        buyButtonText = buyButton.GetComponentInChildren<Text>();

        //buyButtonText.text = Cost.ToString();
        buyButtonText.text = MoneyFormatter.FormatMoney(Cost);

        buyButton.SetActive(!isUnlocked);

        buildingVisuals.SetActive(isUnlocked);

        collectProfitButtonText = collectProfitButton.GetComponentInChildren<Text>();

        collectProfitButton.SetActive(isUnlocked);

        // 업그레이드 초기화
        upgradeButtonText = upgradeButton.GetComponentInChildren<Text>();
        upgradeButton.SetActive(isUnlocked);
        UpdateUpgradeUI();

        StartCoroutine(MakeProfit());

    }

    IEnumerator MakeProfit()
    {
        while(true)
        {
            if(isUnlocked)
            {
                profit += buildingLvl * profitMultiplier;
                UpdateProfitUI();
            }

            yield return new WaitForSecondsRealtime(1f);
        }
    }

    void UpdateProfitUI()
    {
        //collectProfitButtonText.text = profit.ToString();
        collectProfitButtonText.text = MoneyFormatter.FormatMoney(profit);
    }

    // 업그레이드 UI
    void UpdateUpgradeUI()
    {
        upgradeButtonText.text = $"^\nLVL{buildingLvl}\n{MoneyFormatter.FormatMoney(NextUpgradeCost)}";
    }

    public void OnBuyButton()
    {
        if(!isUnlocked)
        {
            if(MoneyManager.instance.buy(Cost))
            {
                isUnlocked = true;

                buildingVisuals.SetActive(isUnlocked);
                buyButton.SetActive(!isUnlocked);

                collectProfitButton.SetActive(isUnlocked);

                upgradeButton.SetActive(isUnlocked);
            }
        }
    }

    public void OnCollectProfitButton()
    {
        MoneyManager.instance.AddMoney(profit);
        profit = 0;

        UpdateProfitUI();
    }

    // 업그레이드 버튼
    public void OnUpgradeButton()
    {
        if(MoneyManager.instance.buy(NextUpgradeCost))
        {
            buildingLvl += 1;
            UpdateUpgradeUI();
        }
    }

    // 건물 데이터 저장
    void SaveBuildingData()
    {
        // 건물저장 데이터의 객체를 만들었다.
        BuildingData bd = new BuildingData(isUnlocked, buildingLvl, profit.ToString());
        // 데이터를 Json으로 변경한다.
        string json = BuildingData.CreateJSONFromBuilding(bd);
        // Json 으로 만든 String 에 id 를 더하여 저장한다.
        PlayerPrefs.SetString("building" + id, json);

        PlayerPrefs.Save();
    }

    void LoadBuildingData()
    {
        // id 를 붙이는 것이 중요 하다.
        // id 는 각 건물이 가지고 있는 id
        string json = PlayerPrefs.GetString("building" + id, "");

        BuildingData bd = null;

        if(json.Equals(""))
        {
            // 건물 데이터가 비어있다면 새로운 건물 데이터를 만들고 초기화한다.
            // 저장되어 있는 것이 없다는 것 또는 로드 실패
            bd = new BuildingData(false, 1, "0");
        }
        else
        {
            // 데이터가 있다면 객체에 데이터를 대입한다.
            bd = BuildingData.CreateBuildingFromJSON(json);
        }

        // 임시 저장했던 데이터를 실제 보이는 것에 방영한다.
        isUnlocked = bd.IsUnlocked;
        buildingLvl = bd.BuildingLvl;
        profit = BigInteger.Parse(bd.Profit);

    }

    void Awake()
    {
        LoadBuildingData();
    }

    // 앱이 일시정지되었을 때 저장한다.
    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveBuildingData();
        }
    }

    void OnApplicationQuit()
    {
        SaveBuildingData();
    }

}
