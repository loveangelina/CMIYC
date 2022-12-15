using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;

    int index = 0;
    [SerializeField] AudioClip[] audioClip;

    void Awake()
    {
        int numberGameSessions = FindObjectsOfType<AudioManager>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject); 
    }

    public void ChangeClip()
    {
        audioSource.Stop();
        audioSource.clip = audioClip[++index];
        audioSource.Play();
    }
}
