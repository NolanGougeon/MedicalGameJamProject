using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaving : MonoBehaviour
{
    public static GameSaving gameSaving;
    private static string jsonSavePath ="";

    public string sceneName;
    public float score;

    public static string lSceneName;
    public static float lScore;

    public static bool isLoaded = false;

    private void Awake()
    {
        if(gameSaving == null)
        {
            gameSaving = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void LoadData()
    {
        GameSaving gameSaving = JsonUtility.FromJson<GameSaving>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));

        GameSaving.lSceneName = gameSaving.sceneName;
        GameSaving.lScore = gameSaving.score;

        SceneManager.LoadScene(gameSaving.sceneName);

        //For testing purposes
      
        
        GameSaving.isLoaded = true;
    }

    public static void SaveData(float score)
    {
        //References
        Scene scene = SceneManager.GetActiveScene();
        GameSaving gameSaving = new GameSaving();
        //Scene Name
        gameSaving.sceneName = scene.name;

        //Position
       
        GameSaving.lSceneName = gameSaving.sceneName;

        //Rotation
        gameSaving.score = score;
        GameSaving.lScore = gameSaving.score;

        string jsonData = JsonUtility.ToJson(gameSaving, true);
        File.WriteAllText(jsonSavePath, jsonData);

    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
