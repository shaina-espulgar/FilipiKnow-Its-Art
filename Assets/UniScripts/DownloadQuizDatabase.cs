using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
[HideInInspector]
public class QuizList
{
    public List<QuizName> QuizName = new List<QuizName>();
}

[System.Serializable]
public class QuizName
{
    public string Quiz;
    public string FileURL;
}

public class DownloadQuizDatabase : MonoBehaviour
{
    // Loads all of the Quizzes inside Google Drive
    public QuizList QuizList = new QuizList();

    private readonly string[] questionTypes = { "Classicart", "Switchart", "Classifyart", "Matchart", "Grabart", "TicTacToe", "Maze" };

    [Header("Quizloader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Debug Menu")]
    [SerializeField] private DebugMessage debugMessage;

    // Json Google Drive Link
    readonly string jsonURL = "https://drive.google.com/uc?export=download&id=1N27nMhcAJT4DWBzTboLfZ9UvGeWN4j-I";
    string filepath;

    int questionDownloaded = 0;
    public bool DownloadQuizzes()
    {
        StartCoroutine(GetData(jsonURL));

        if (questionDownloaded == questionTypes.Length)
        {
            CheckQuiz();
        }

        return CheckQuiz();
    }

    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error GetData");
        }
        else
        {
            // Success
            TextAsset asset = Resources.Load("CollectQuiz") as TextAsset;

            QuizList = JsonUtility.FromJson<QuizList>(request.downloadHandler.text);

            foreach (QuizName name in QuizList.QuizName)
            {
                foreach (string type in questionTypes)
                {
                    if (name.Quiz == type)
                    {
                        StartCoroutine(GetQuiz(name.FileURL, type));

                        questionDownloaded++;
                    }
                }
            }
        }



        request.Dispose();
    }

    IEnumerator GetQuiz(string url, string typeOfQuestion)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error GetQuiz");
        }
        else
        {
            filepath = Application.persistentDataPath + "/" + typeOfQuestion + ".csv";

            string[] csvReplace = request.downloadHandler.text.Split(new string[] { "\n" }, StringSplitOptions.None).ToArray();
            File.WriteAllLines(filepath, csvReplace);

            debugMessage.OnDownloadComplete(typeOfQuestion);
            Debug.Log("File: " + typeOfQuestion + " Replaced");
        }
        request.Dispose();
    }

    public bool CheckQuiz()
    {
        for(int i = 0; i < questionTypes.Length; i++)
        {
            if (File.Exists(Application.persistentDataPath + "/" + questionTypes[i] + ".csv"))
            {
                // Conditions if that file exists
                Debug.Log(questionTypes[i] + "verified!");
            }
            else
            {
                Debug.Log(questionTypes[i] + "unknown. Cancelling...");
                return false;
            }
        }

        return true;
    }
}