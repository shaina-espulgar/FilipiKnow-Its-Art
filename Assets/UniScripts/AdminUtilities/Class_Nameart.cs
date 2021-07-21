using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using SimpleFileBrowser;
using System.IO;

public class Class_Nameart : MonoBehaviour
{


    /*
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [SerializeField]
    private RawImage input_Image;

    [SerializeField]
    private TMP_InputField[] arrChoices;
    [SerializeField]
    private TMP_InputField input_Answer;

    string path;

    public void Display()
    {
        string question = quizLoader.Question;
        string[] choices = quizLoader.Choices;
        string[] answers = quizLoader.Answers;

        input_Image.texture = (Texture)AssetDatabase.LoadAssetAtPath(Application.dataPath + question, typeof(Texture));
        int index = 0;
        foreach (string text in choices)
        {
            arrChoices[index].text = text;
            index++;
        }
        input_Answer.text = answers[0];
    }

    public void Modify(string operation)
    {

    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        GetImage();
    }

    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        // WWW www = new WWW("file:///" + path);
        // input_Image.texture = www.texture;
    }
    */
}
