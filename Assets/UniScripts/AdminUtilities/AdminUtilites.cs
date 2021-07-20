using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdminUtilites : MonoBehaviour
{
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
    [SerializeField] private Class_Classicart class_Classicart;
    [SerializeField] private Class_Matchart class_Matchart;
    [SerializeField] private Class_Switchart class_Switchart;
    [SerializeField] private Class_Grabart class_Grabart;
    [SerializeField] private Class_Nameart class_Nameart;
    [SerializeField] private Class_Classifyart class_Classifyart;
    [SerializeField] private Class_TicTacToe class_TicTacToe;
    [SerializeField] private Class_Maze class_Maze;

    [Header("Question Number")]
    [SerializeField] private TMP_Text questionNumber;

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
            quizLoader.indexQuestion = 0;
        });
    }

    public void OpenPanel(Dropdown dropDownQuizList)
    {
        int index = dropDownQuizList.value;
        currentPanel = dropDownQuizList.options[index].text;

        quizLoader.LoadCSV(currentPanel);
        questionNumber.text = Convert.ToString(quizLoader.indexQuestion + 1) + "/" + Convert.ToString(quizLoader.data_questionSet.Length);
        switch (dropDownQuizList.options[index].text)
        {
            case "Classicart": Panel_Classicart(); break;
            case "Matchart": Panel_Matchart(); break;
            case "Switchart": Panel_Switchart(); break;
            case "Grabart": Panel_Grabart(); break;
            case "Nameart": Panel_Nameart(); break;
            case "Classifyart": Panel_Classifyart(); break;
            case "TicTacToe": Panel_TicTacToe(); break;
            case "Maze": Panel_Maze(); break;
        }
    }

    public void EditCSV()
    {
        int index = dropDownQuizList.value;
        switch (dropDownQuizList.options[index].text)
        {
            case "Classicart": class_Classicart.Modify("edit"); break;
            case "Matchart": class_Matchart.Modify("edit"); break;
            case "Switchart": class_Switchart.Modify("edit"); break;
            case "Grabart": class_Grabart.Modify("edit"); break;
            // case "Nameart": class_Nameart.Modify("edit"); break;
            case "Classifyart": class_Classifyart.Modify("edit"); break;
            case "TicTacToe": class_TicTacToe.Modify("edit"); break;
            case "Maze": class_Maze.Modify("edit"); break;
        }
    }

    public void CreateNew()
    {
        int index = dropDownQuizList.value;
        switch (dropDownQuizList.options[index].text)
        {
            case "Classicart": class_Classicart.Modify("add"); break;
            case "Matchart": class_Matchart.Modify("add"); break;
            case "Switchart": class_Switchart.Modify("add"); break;
            case "Grabart": class_Grabart.Modify("add"); break;
            // case "Nameart": class_Nameart.Modify("add"); break;
            case "Classifyart": class_Classifyart.Modify("add"); break;
            case "TicTacToe": class_TicTacToe.Modify("add"); break;
            case "Maze": class_Maze.Modify("add"); break;
        }
    }

    public void DeleteQuestion()
    {
        int indexToRemove = quizLoader.indexQuestion + 1;
        string[] arrline = File.ReadAllLines(quizLoader.filepath);

        int index = dropDownQuizList.value;
        if (dropDownQuizList.options[index].text == "Matchart" || dropDownQuizList.options[index].text == "Grabart")
        {
            for (int i = indexToRemove + (1 * 2); i < arrline.Length / 2; i++)
            {
                arrline[i] = arrline[i + 2];
            }
            Array.Resize(ref arrline, arrline.Length - 2);  
        }
        else
        {
            for (int i = indexToRemove; i < arrline.Length - 1; i++)
            {
                arrline[i] = arrline[i + 1];
            }
            Array.Resize(ref arrline, arrline.Length - 1);
        }
        File.WriteAllLines(quizLoader.filepath, arrline);
    }

    public void Previous()
    {
        int index = dropDownQuizList.value;
        if (dropDownQuizList.options[index].text == "Grabart" || dropDownQuizList.options[index].text == "Matchart")
        {
            quizLoader.indexQuestion-= 2;
        }
        else
        {
            quizLoader.indexQuestion--;
        }

        if (quizLoader.indexQuestion < 0)
        {
            quizLoader.indexQuestion = quizLoader.data_questionSet.Length - 1;
        }
        OpenPanel(dropDownQuizList);
    }

    public void Next()
    {
        int index = dropDownQuizList.value;
        if (dropDownQuizList.options[index].text == "Grabart" || dropDownQuizList.options[index].text == "Matchart")
        {
            quizLoader.indexQuestion+=2;
        }
        else
        {
            quizLoader.indexQuestion++;
        }

        if (quizLoader.indexQuestion > quizLoader.data_questionSet.Length - 1)
        {
            quizLoader.indexQuestion = 0;
        }
        OpenPanel(dropDownQuizList);
    }

    public void Panel_Classicart()
    {
        UI_Classicart.SetActive(true);
        class_Classicart.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Classicart.SetActive(false);
        });
    }

    public void Panel_Matchart()
    {
        UI_Matchart.SetActive(true);
        class_Matchart.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Matchart.SetActive(false);
        });
    }

    public void Panel_Switchart()
    {
        UI_Switchart.SetActive(true);
        class_Switchart.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Switchart.SetActive(false);
        });
    }

    public void Panel_Grabart()
    {
        UI_Grabart.SetActive(true);
        class_Grabart.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Grabart.SetActive(false);
        });
    }
    
    public void Panel_Nameart()
    {
        UI_Nameart.SetActive(true);
        // class_Nameart.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Nameart.SetActive(false);
        });
    }

    public void Panel_Classifyart()
    {
        UI_Classifyart.SetActive(true);
        class_Classifyart.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Classifyart.SetActive(false);
        });
    }

    public void Panel_TicTacToe()
    {
        UI_TicTacToe.SetActive(true);
        class_TicTacToe.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_TicTacToe.SetActive(false);
        });
    }

    public void Panel_Maze()
    {
        UI_Maze.SetActive(true);
        class_Maze.Display();

        dropDownQuizList.onValueChanged.AddListener(delegate {
            UI_Maze.SetActive(false);
        });
    }

}
