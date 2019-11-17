using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnswerSaving : MonoBehaviour
{
    public static AnswerSaving answerSaving;
    private static string jsonSavePath = "";

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

    private void Awake()
    {
        if (answerSaving == null)
        {
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

    public static void SaveData(string question, string answer)
    {
        //References
        Scene scene = SceneManager.GetActiveScene();
        AnswerSaving answerSaving = new AnswerSaving();
        //Scene Name
        AnswerSaving.lTotalCount += 1;
        answerSaving.sceneName = scene.name;

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

    }
}
