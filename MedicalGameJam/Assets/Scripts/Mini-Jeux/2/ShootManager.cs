using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    PlayerController p;
    private float value;
    private int v;
    private EnnemiController[] ennemies;

    [SerializeField] GameObject victoryButton, retryButton;

    private AudioSource audioSource;
    [SerializeField] AudioClip winSound, loseSound;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        p = player.GetComponent<PlayerController>();

        ennemies = GameObject.FindObjectsOfType<EnnemiController>();
        v = ennemies.Length;
    }

    private void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        ennemies = GameObject.FindObjectsOfType<EnnemiController>();
        value = p.mLUsed;
        
        if (ennemies.Length == 0 && !gameOver)
        {
            Victory();
            gameOver = true;
        }
        else if((p.mLUsed > p.mLMaxUsed || Time.realtimeSinceStartup== 90) && !gameOver)
        {
            Defeat();
            gameOver = true;
        }
    }

    private void Victory()
    {
        PlaySound(winSound);
        victoryButton.SetActive(true);
        return;
        if (LoadSceneManager.Instance)
            LoadSceneManager.Instance.LoadNextScene();

    }
     private void Defeat()
    {
        PlaySound(loseSound);
        retryButton.SetActive(true);
        return;
        if (LoadSceneManager.Instance)
            LoadSceneManager.Instance.ReloadScene();
     }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }
}
