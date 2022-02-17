using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetizationStrategy : MonoBehaviour
{

    [SerializeField] GameObject DoubleMoneyPanel;
    [SerializeField] float doubleMoneyAdInterval = 60f;

    // 60초마다 광고를 출력하는 것
    IEnumerator DoubleMoneyAdRoutine()
    {
        DoubleMoneyPanel.SetActive(false);

        while(true)
        {
            yield return new WaitForSeconds(doubleMoneyAdInterval);

            if(!DoubleMoneyPanel.activeSelf)
            {
                DoubleMoneyPanel.SetActive(true);
            }
        }
    }

    void Start()
    {
        StartCoroutine(DoubleMoneyAdRoutine());
    }


}
