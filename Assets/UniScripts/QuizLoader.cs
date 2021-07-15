using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizLoader : MonoBehaviour
{
    // This will load every CSV files when placed in the game
    public TextAsset[] textAssetData;
    // Will get its specific filepath
    string filepath = string.Empty;

    // Text the specific quiz question
    public Text questionDisplay;
    public InputField questionEdit;
    // public Text questionCreate;

    // Lists all of the Quiz Databases
    public Dropdown dropDownQuizList;

    public TMP_InputField createQuestion;
    public TMP_InputField createChoices_1;
    public TMP_InputField createChoices_2;
    public TMP_InputField createChoices_3;
    public TMP_InputField createChoices_4;
    public TMP_InputField createAnswer;

    int indexQuestion = 0;

    string[] data_questionSet;
    string[] data_display;

    private void Start()
    {
        // For Dropdown Options
        for (int i = 0; i < textAssetData.Length; i++)
        {
            dropDownQuizList.options.Add(new Dropdown.OptionData() { text = textAssetData[i].name });
        }
        dropDownQuizList.onValueChanged.AddListener(delegate { LoadCSV(dropDownQuizList); indexQuestion = 0; });

        LoadCSV(dropDownQuizList);
    }

    private void LoadCSV(Dropdown dropDownQuizList)
    {
        filepath = Application.dataPath + "/Quiz Database/" + textAssetData[dropDownQuizList.value].name + ".csv";
        if (new FileInfo(filepath).Length == 0)
        {
            dropDownQuizList.value = 0;
        }
        data_questionSet = File.ReadAllLines(filepath);

        data_display = data_questionSet[indexQuestion].Split(new string[] { "," }, StringSplitOptions.None);

        createQuestion.text = data_display[1];
        createChoices_1.text = data_display[2];
        createChoices_2.text = data_display[3];
        createChoices_3.text = data_display[4];
        createChoices_4.text = data_display[5];
        createAnswer.text = data_display[6];
    }

    public void EditCSV()
    {
        data_display[1] = createQuestion.text;
        data_display[2] = createChoices_1.text;
        data_display[3] = createChoices_2.text;
        data_display[4] = createChoices_3.text;
        data_display[5] = createChoices_4.text;
        data_display[6] = createAnswer.text;

        string combine = string.Empty;
        string reserve = string.Empty;
        for (int i = 0; i < data_display.Length; i++)
        {
            if (i == data_display.Length - 1)
            {
                combine = reserve + data_display[i];
                data_questionSet[indexQuestion] = combine;
            }
            else
            {
                combine = reserve + data_display[i] + ",";
                reserve = combine;
            }
        }

        string[] arrline = File.ReadAllLines(filepath);
        arrline[indexQuestion] = combine;
        File.WriteAllLines(filepath, arrline);
    }

    public void CreateNew()
    {
        string numbering = Convert.ToString(data_questionSet.Length + 1);
        string newQuestion =  numbering + "," + createQuestion.text + "," + createChoices_1.text + "," + createChoices_2.text + "," +
            createChoices_3.text + "," + createChoices_4.text + "," + createAnswer.text;

        data_questionSet = data_questionSet.Concat(new string[] { newQuestion }).ToArray();

        string[] arrline = File.ReadAllLines(filepath);
        List<string> listline = arrline.ToList();
        listline.Add(data_questionSet[data_questionSet.Length - 1]);
        File.WriteAllLines(filepath, listline);
    }

    public void DeleteQuestion()
    {
        int indexToRemove = indexQuestion;
        data_questionSet = data_questionSet.Where((source, index) => index != indexToRemove).ToArray();

        string[] arrline = data_questionSet;
        File.WriteAllLines(filepath, arrline);
    }

    public void Previous()
    {
        indexQuestion--;
        if (indexQuestion < 0)
        {
            indexQuestion = data_questionSet.Length - 1;
        }

        LoadCSV(dropDownQuizList);
    }

    public void Next()
    {
        indexQuestion++;
        if (indexQuestion > data_questionSet.Length - 1)
        {
            indexQuestion = 0;
        }

        LoadCSV(dropDownQuizList);
    }
}

