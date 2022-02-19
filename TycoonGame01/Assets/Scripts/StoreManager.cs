using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public void On100kWonPurchaseCompete()
    {
        MoneyManager.instance.AddMoney(100000);
    }

    public void OnRemoveAdsPurchaseComplete()
    {
        PlayerPrefs.SetInt("adsRemoved", 1);
    }

    public void OnHireManagerPurchaseComplete()
    {
        FindObjectOfType<ProfitCollector>().HireManager();
    }
}
