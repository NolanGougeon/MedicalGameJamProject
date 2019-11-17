using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerSaving : MonoBehaviour
{
    public static AnswerSaving answerSaving;
    private static string jsonSavePath = "answers.txt";
    
    public string sceneName;
    public string question;
    public string answer;
    public int answerCount;
    public int totalCount;


    public static string lSceneName;
    public static string lQuestion;
    public static string lAnswer;
    public static int lAnswerCount;
    public static int lTotalCount;

    public static bool isLoaded = false;

    private void Start()
    {
        if (answerSaving == null)
        {
            Debug.Log("AS instancied");
           answerSaving = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
    public static void LoadData()
    {
       /* AnswerSaving answerSaving = JsonUtility.FromJson<AnswerSaving>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));

        AnswerSaving.lSceneName = answerSaving.sceneName;
        AnswerSaving.l = answerSaving.score;

        SceneManager.LoadScene(answerSaving.sceneName);

        //For testing purposes


        AnswerSaving.isLoaded = true;*/
    }

    public static void SaveData(string question, string answer,int index)
    {
        Debug.Log("Started Saving");
        
       
        //References
        Scene scene = SceneManager.GetActiveScene();
        
        //Scene Name
        AnswerSaving.lTotalCount += 1;
        answerSaving.sceneName = scene.name;
        Debug.Log(answerSaving.sceneName);
        //Position

        AnswerSaving.lSceneName = answerSaving.sceneName;

        //Rotation
        answerSaving.question = question;
        AnswerSaving.lQuestion = answerSaving.question;

        answerSaving.answer = answer;
        AnswerSaving.lAnswer = answerSaving.answer;
        answerSaving.answerCount+=1;
        AnswerSaving.lAnswerCount = answerSaving.answerCount;
        answerSaving.totalCount = AnswerSaving.lTotalCount;
        
        

        
        string jsonData = JsonUtility.ToJson(answerSaving, true);
        File.WriteAllText(jsonSavePath, jsonData);
        Debug.Log(jsonData);
        
       File.WriteAllText(jsonSavePath, jsonData);

    }
}
