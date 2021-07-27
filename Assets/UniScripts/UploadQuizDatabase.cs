using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class UploadQuizDatabase : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] public QuizLoader quizLoader = new QuizLoader();

    [Header("Debug Message")]
    // Creating yet

    [Header("Game Object")]
    [SerializeField] private GameObject promptWindow;
    private GameObject permissionWindow = null;

    [Header("Dropdown Quizzes")]
    [SerializeField] private TMP_Dropdown dropDownQuizzes;

    [Header("Button")]
    [SerializeField] private Button promptToDrive;

    private string typeOfQuestion;
    public void Start()
    {
#if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            permissionWindow = new GameObject();
        }
#endif

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

    public void OnGUI()
    {
        #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            permissionWindow.AddComponent<PermissionsRationaleDialog>();
            return;
        }
        else if (permissionWindow != null)
        {
            Destroy(permissionWindow);
        }
        #endif
    }
    public void PromptToDrive()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/19IiRLlSXbSb-61mrpcGPXB1sP0CAgREf?usp=sharing");
    }

    public void SendCSVtoPath()
    {
#if UNITY_STANDALONE
        // For PC test
        Directory.CreateDirectory("D:/Filipiknows/");
        string exportPath = "D:/Filipiknows/" + typeOfQuestion + ".csv";
        // For Android test
        // string exportPath = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS); 

        quizLoader.filepath = Application.persistentDataPath + "/Quiz Database/" + typeOfQuestion + ".csv";

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
#endif

#if UNITY_ANDROID
        Directory.CreateDirectory("/storage/emulated/0/Downloads/Filipiknow-Its-Art");  
        quizLoader.filepath = Application.persistentDataPath + "/Quiz Database/" + typeOfQuestion + ".csv";
        string exportPath = "/storage/emulated/0/Downloads/Filipiknow-Its-Art/" + typeOfQuestion + ".csv";

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

#endif

    }
}