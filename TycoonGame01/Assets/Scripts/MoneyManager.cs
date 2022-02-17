using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] Text moneyText;
    
    public BigInteger Money{get; set;}

    // 다른곳에서도 사용할 수 있도록 [싱글톤]으로 만든다.
    public static MoneyManager instance;

    void UpdateMoneyUI()
    {
        // 소유하고 있는 돈의 정보를 표시한다.
        moneyText.text = string.Format("{0}", MoneyFormatter.FormatMoney(Money));
        // string.Format을 이용하여 표현!!
        // {0} : Money, {1} : int
    }

    void Start()
    {
        Money = 0;
        UpdateMoneyUI();
        instance = this;
    }

    public bool buy(BigInteger cost)
    {
        // 구입이 성공했는지 확인하는 변수
        bool isBuyOPSuccessfull = false;

        // 소유하고 있는 돈이 구매 비용보다 많으면 
        if(cost <= Money)
        {
            // 소유돈에서 비용을 뺀다.
            Money -= cost;
            // 샀다는 것을 참으로 바꾼다
            isBuyOPSuccessfull = true;
        }

        // 돈 표시를 갱신산다.
        UpdateMoneyUI();
        // 건물을 샀다는 것을 리턴한다.
        return isBuyOPSuccessfull;
    }

    // 이익을 매개변수로 받는다.
    public void AddMoney(BigInteger profit)
    {
        // 이익이 0 보다 크면
        if(profit > 0)
        {
            // 소유하고 있는 돈을 증가 시킨다.
            Money += profit;
            UpdateMoneyUI();
        }
    }

}
