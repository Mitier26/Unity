using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterController : MonoBehaviour
{
    [SerializeField] GameObject[] monsters;
    [SerializeField] float interval = 3f;

    void Start()
    {
        InvokeRepeating("SpawnMonster", interval, interval);
    }

    void SpawnMonster()
    {
        float ran = Random.value;

        if(ran < 0.2)
        {
            GameObject m = Instantiate(monsters[0], transform.position, Quaternion.identity);
        }
        else if(ran < 0.4)
        {
            GameObject m = Instantiate(monsters[1], transform.position, Quaternion.identity);
        }
        else
        {
            
        }

        
    }
}
