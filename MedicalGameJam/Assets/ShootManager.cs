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
    
    // Start is called before the first frame update
    void Awake()
    {
        p = player.GetComponent<PlayerController>();

        ennemies = GameObject.FindObjectsOfType<EnnemiController>();
        v = ennemies.Length;
    }

    // Update is called once per frame
    void Update()
    {
        ennemies = GameObject.FindObjectsOfType<EnnemiController>();
        value = p.mLUsed;
        
        if (ennemies.Length == 0)
        {
            Victory();
        }
        else if(value > v + 3 || Time.realtimeSinceStartup==90)
        {
            Defeat();
        }
    }

    private void Victory()
    { 
        LoadSceneManager.Instance.LoadNextScene();

    }
     private void Defeat()
    {
        LoadSceneManager.Instance.ReloadScene();
    }
}
