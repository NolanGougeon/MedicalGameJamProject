using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPatientGameManager : MonoBehaviour
{
    private static TapPatientGameManager instance;
    public static TapPatientGameManager Instance { get { return instance; } }
    [SerializeField] TapCharacterGeneratorController generator;

    [SerializeField] GameObject panel;

    private AudioSource audioSource;
    [SerializeField]
    AudioClip winSound;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {

        PlaySound(winSound);
        generator.generate = false;
        panel.SetActive(true);
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }

}
