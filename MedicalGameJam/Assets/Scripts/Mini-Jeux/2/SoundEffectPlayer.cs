using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundEffect;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void Play()
    {
        audioSource.clip = soundEffect;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
        Destroy(gameObject, soundEffect.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
