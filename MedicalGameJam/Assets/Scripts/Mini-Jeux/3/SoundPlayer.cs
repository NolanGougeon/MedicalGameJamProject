using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] audio;
    AudioSource source;

    private static SoundPlayer instance;
    public static SoundPlayer Instance { get { return instance; } }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = null;
    }

    public void PlayWinSound()
    {
        source.clip = audio[0];
        source.Play();
    }

    public void PlayLoseSound()
    {
        source.clip = audio[1];
        source.Play();
    }
}
