using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityGoogleDrive;


[System.Serializable]
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

    private readonly string[] questionTypes = { "Classicart", "Switchart", "Classifyart", "Matchart", "Grabart", "TicTacToe", "Maze"};

    [Header("Quizloader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Debug Menu")]
    [SerializeField] private TMP_Text debugText;

    // Json Google Drive Link
    readonly string jsonURL = "https://drive.google.com/uc?export=download&id=1N27nMhcAJT4DWBzTboLfZ9UvGeWN4j-I";

    void Start()
    {
        StartCoroutine(GetData(jsonURL));

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
                    }
                }
            }

        }
        request.Dispose();
    }

    IEnumerator GetQuiz(string url, string questionType)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error GetQuiz");
        }
        else
        {
            quizLoader.filepath = Application.dataPath + "/Quiz Database/" + questionType + ".csv";

            string[] csvReplace = request.downloadHandler.text.Split(new string[] { "\n" }, StringSplitOptions.None).ToArray();
            File.WriteAllLines(quizLoader.filepath, csvReplace);

            debugText.text = questionType + " Replaced";
            Debug.Log("File: " + questionType + " Replaced");

            
        }
        request.Dispose();
    }
}


