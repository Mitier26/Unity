using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashlDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            Invoke("ReloadScene", loadDelay);            
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
