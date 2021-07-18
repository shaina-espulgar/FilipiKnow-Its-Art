using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity.UI;
using TMPro;

public class AdminUtilites : MonoBehaviour
{
    /* 
    Text the specific quiz question

    public Text questionDisplay;
    public InputField questionEdit;
    public Scrollbar editor;
    public Text questionCreate;
    */

    // Lists all of the Quiz Databases
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    // GameObjects that will be presented inside the ScrollView
    [Header("GameObjects")]
    public GameObject UI_Classicart;
    public GameObject UI_Matchart;
    public GameObject UI_Switchart;
    public GameObject UI_Grabart;
    public GameObject UI_Nameart;
    public GameObject UI_Classifyart;
    public GameObject UI_TicTacToe;
    public GameObject UI_Maze;

    [Header("Dropdown")]
    [SerializeField] private Dropdown dropDownQuizList;

    [Header("Classes")]
    [SerializeField] private Class_Classicart classicart;

    int indexQuestion = 0;

    string[] data_questionSet;
    string[] data_display;

    string currentPanel;

    private void Start()
    {
        // For Dropdown Options
        for (int i = 0; i < quizLoader.TextAssetData.Length; i++)
        {
            dropDownQuizList.options.Add(new Dropdown.OptionData() { text = quizLoader.TextAssetData[i].name });
        }
        OpenPanel(dropDownQuizList);

        dropDownQuizList.onValueChanged.AddListener(delegate {
            OpenPanel(dropDownQuizList); 
        });
    }

    public void OpenPanel(Dropdown dropDownQuizList)
    {
        int index = dropDownQuizList.value;
        currentPanel = dropDownQuizList.options[index].text;

        switch (dropDownQuizList.options[index].text)
        {
            case "Classicart": Panel_Classicart(); break;
            case "Matchart": Panel_Matchart(); break;
            case "Switchart": Panel_Switchart(); break;
            case "Grabart": Panel_Grabart(); break;
            case "Nameart": Panel_Grabart(); break;
            case "Classifyart": Panel_Classifyart(); break;
            case "TicTacToe": Panel_TicTacToe(); break;
            case "Maze": Panel_Maze(); break;
        }


    }

    public void EditCSV()
    {
        // quizLoader.LoadCSV(dropDownQuizList.name);
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

        string[] arrline = File.ReadAllLines(quizLoader.filepath);
        arrline[indexQuestion] = combine;
        File.WriteAllLines(quizLoader.filepath, arrline);
    }

    public void CreateNew()
    {
        // quizLoader.LoadCSV(dropDownQuizList.name);
        string numbering = Convert.ToString(data_questionSet.Length + 1);
        // string newQuestion = createQuestion.text + "," + createChoices_1.text + "," + createChoices_2.text + "," +
        //    createChoices_3.text + "," + createChoices_4.text + "," + createAnswer.text;

        // data_questionSet = data_questionSet.Concat(new string[] { newQuestion }).ToArray();

        string[] arrline = File.ReadAllLines(quizLoader.filepath);
        List<string> listline = arrline.ToList();
        listline.Add(data_questionSet[data_questionSet.Length - 1]);
        File.WriteAllLines(quizLoader.filepath, listline);
    }

    public void DeleteQuestion()
    {
        // quizLoader.LoadCSV(dropDownQuizList.name);
        int indexToRemove = indexQuestion;
        data_questionSet = data_questionSet.Where((source, index) => index != indexToRemove).ToArray();

        string[] arrline = data_questionSet;
        File.WriteAllLines(quizLoader.filepath, arrline);
    }

    public void Previous()
    {
        quizLoader.indexQuestion--;
        if (quizLoader.indexQuestion < 0)
        {
            quizLoader.indexQuestion = quizLoader.data_questionSet.Length - 1;
        }
        quizLoader.LoadCSV(currentPanel);
    }

    public void Next()
    {
        quizLoader.indexQuestion++;
        if (quizLoader.indexQuestion > quizLoader.data_questionSet.Length - 1)
        {
            quizLoader.indexQuestion = 0;
        }
        quizLoader.LoadCSV(currentPanel);
    }

    public void Panel_Classicart()
    {
        UI_Classicart.SetActive(true);

        quizLoader.LoadCSV(currentPanel);
        classicart.QuizLoad();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Classicart.SetActive(false);
        });
    }

    public void Panel_Matchart()
    {
        UI_Matchart.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Matchart.SetActive(false);
        });
    }

    public void Panel_Switchart()
    {
        UI_Switchart.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Switchart.SetActive(false);
        });
    }

    public void Panel_Grabart()
    {
        UI_Grabart.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Grabart.SetActive(false);
        });
    }
    
    public void Panel_Nameart()
    {
        UI_Nameart.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Nameart.SetActive(false);
        });
    }

    public void Panel_Classifyart()
    {
        UI_Classifyart.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Classifyart.SetActive(false);
        });
    }

    public void Panel_TicTacToe()
    {
        UI_TicTacToe.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_TicTacToe.SetActive(false);
        });
    }

    public void Panel_Maze()
    {
        UI_Maze.SetActive(true);
        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Maze.SetActive(false);
        });
    }

}
