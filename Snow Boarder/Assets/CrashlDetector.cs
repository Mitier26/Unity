using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashlDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            
        }
    }
}
