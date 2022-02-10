using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float unlockingSpeed = 2;
    [SerializeField] float unLockingTime = 3;
    [SerializeField] bool isDoorUnlocked = false;

    public void UnlockDoor()
    {
        isDoorUnlocked = true;
    }

    void Update()
    {
        if(isDoorUnlocked)
        {
            unLockingTime -= Time.deltaTime;
            transform.Translate(Vector3.down * Time.deltaTime * unlockingSpeed);

            if(unLockingTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
