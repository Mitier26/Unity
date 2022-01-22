using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashlDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip audioClip;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            GetComponent<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(audioClip);
            Invoke("ReloadScene", loadDelay);            
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
