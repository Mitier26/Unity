using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damegeClip;
    [SerializeField] [Range(0f, 1f)] float damegeVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();    
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayerShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayerDammegeClip()
    {
        if (damegeClip != null)
        {
            AudioSource.PlayClipAtPoint(damegeClip, Camera.main.transform.position,damegeVolume);
        }
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
