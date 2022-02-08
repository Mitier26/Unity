using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionPlayerWithEnemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    void OnDisable()
    {
        SceneManager.LoadScene(0);
    }
}
