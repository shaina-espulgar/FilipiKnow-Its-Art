using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UploadQuizDatabase : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] public QuizLoader quizLoader = new QuizLoader();

    [Header("Debug Message")]
    // Creating yet

    [Header("Game Object")]
    [SerializeField] private GameObject promptWindow;

    [Header("Dropdown Quizzes")]
    [SerializeField] private TMP_Dropdown dropDownQuizzes;

    [Header("Button")]
    [SerializeField] private Button promptToDrive;

    private string typeOfQuestion;
    public void Start()
    {
        // For Dropdown Options
        for (int i = 0; i < quizLoader.TextAssetData.Length; i++)
        {
            dropDownQuizzes.options.Add(new TMP_Dropdown.OptionData() { text = quizLoader.TextAssetData[i].name });
        }

        dropDownQuizzes.onValueChanged.AddListener(delegate
        {
            int index = dropDownQuizzes.value;
            typeOfQuestion = dropDownQuizzes.options[index].text;
        });

        promptToDrive.interactable = false;
    }

    public void PromptToDrive()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/19IiRLlSXbSb-61mrpcGPXB1sP0CAgREf?usp=sharing");
    }

    public void SendCSVtoPath()
    {
        // For PC test
        Directory.CreateDirectory("D:/Filipiknows/");
        string exportPath = "D:/Filipiknows/" + typeOfQuestion + ".csv";
        // For Android test
        // string exportPath = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS); 

        quizLoader.filepath = Application.dataPath + "/Quiz Database/" + typeOfQuestion + ".csv";

        string[] csvFile = File.ReadAllLines(quizLoader.filepath);

        if (!File.Exists(exportPath))
        {
            File.WriteAllLines(exportPath, csvFile);
            promptToDrive.interactable = true;
            Debug.Log("File has been exported");
        }
        else
        {
            File.AppendAllLines(exportPath, csvFile);
            promptToDrive.interactable = true;
            Debug.Log("File has been exported");
        }


    }
}
