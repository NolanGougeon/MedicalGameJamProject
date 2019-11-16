using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPatientGameManager : MonoBehaviour
{
    private static TapPatientGameManager instance;
    public static TapPatientGameManager Instance { get { return instance; } }
    [SerializeField] TapCharacterGeneratorController generator;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
        generator.generate = false;
    }


}
