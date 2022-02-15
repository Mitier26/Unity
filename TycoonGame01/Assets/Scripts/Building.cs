using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class Building : MonoBehaviour
{
    [SerializeField] GameObject buildingVisuals;
    [SerializeField] GameObject buyButton;
    [SerializeField] string costRepresentation;

    [SerializeField] GameObject collectProfitButton;

    Text collectProfitButtonText;

    [SerializeField] int buildingLvl = 1;
    [SerializeField] int profitMultiplier = 1;
    [SerializeField] BigInteger profit;
    
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

        buyButtonText.text = Cost.ToString();

        buyButton.SetActive(!isUnlocked);

        buildingVisuals.SetActive(isUnlocked);

        collectProfitButtonText = collectProfitButton.GetComponentInChildren<Text>();

        collectProfitButton.SetActive(isUnlocked);

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
        collectProfitButtonText.text =profit.ToString();
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
            }
        }
    }

    public void OnCollectProfitButton()
    {
        MoneyManager.instance.AddMoney(profit);
        profit = 0;

        UpdateProfitUI();
    }

}
