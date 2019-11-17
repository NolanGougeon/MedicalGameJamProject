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
    public int[] answerCount;
    public int totalCount;


    public static string lSceneName;
    public static string lQuestion;
    public static string lAnswer;
    public static int[] lAnswerCount;
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
        GameSaving gameSaving = JsonUtility.FromJson<GameSaving>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));

        GameSaving.lSceneName = gameSaving.sceneName;
        GameSaving.lScore = gameSaving.score;

        SceneManager.LoadScene(gameSaving.sceneName);

        //For testing purposes


        GameSaving.isLoaded = true;
    }

    public static void SaveData(string question, string answer,int index)
    {
        Debug.Log("Started Saving");
        
        Dictionary<string, string[]> d = new Dictionary<string, string[]>();

        Debug.Log("dictionnary created");
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
        answerSaving.answerCount[index-1]+=1;
        AnswerSaving.lAnswerCount[index] = answerSaving.answerCount[index-1];
        answerSaving.totalCount = AnswerSaving.lTotalCount;

        d.Add(question, new[]{ answer,((answerSaving.answerCount[index-1]  *100)/AnswerSaving.lTotalCount)+""});

        Debug.Log("dictionnary created "+d.Count);
        string jsonData = JsonUtility.ToJson(d, true);
        Debug.Log(jsonData);
        File.WriteAllText(jsonSavePath, jsonData);

    }
}
