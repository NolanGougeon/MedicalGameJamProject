using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("SM instancied");
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void SaveAnswer(string q, string a,int index)
    {
        Debug.Log("saving data : " + q + ", " + a);
        AnswerSaving.SaveData(q, a,index);
    }
    
}
