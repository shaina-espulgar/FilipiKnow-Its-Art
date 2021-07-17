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
    [SerializeField]
    private TextAsset[] _textAssetData;
    public TextAsset[] TextAssetData
    {
        get { return _textAssetData; }
        set { _textAssetData = value; }
    }
    
    // Will get its specific filepath
    public string filepath = string.Empty;

    // Text the specific quiz question
    // public Text questionDisplay;
    // public InputField questionEdit;
    // public Text questionCreate;

    // Lists all of the Quiz Databases
    // public Dropdown dropDownQuizList;

    int indexQuestion = 0;
    string typeOfQuestion = null;

    string[] data_questionSet;
    string[] data_display;

    private void Start()
    {

    }

    public void LoadCSV(string typeOfQuestion)
    {
        filepath = Application.dataPath + "/Quiz Database/" + typeOfQuestion + ".csv";

        data_questionSet = File.ReadAllLines(filepath);
        data_display = data_questionSet[indexQuestion].Split(new string[] { "," }, StringSplitOptions.None);
    }

    // Use Getter and Setter so we can get the variable of these stuffs even from the outside
    private string _question;
    public string Question
    {
        get { return _question; }
        set { _question = value; }
    }

    private List<string> _choices;
    public List<string> Choices
    {
        get { return _choices; }
        set { _choices = value; }
    }

    private List<string> _answers;
    public List<string> Answers
    {
        get { return _answers; }
        set { _answers = value; }
    }

    public void Classicart(int index)
    {
        _question = data_display[0];
        for (int i = 0; i <= 4 ; i++)
        {
            _choices.Add(data_display[i]);
        }
        _answers.Add(data_display[5]);
    }

    public void Matchart(int index)
    {
        _question = data_display[0];
        for (int i = 0; i <= 4; i++)
        {
            _choices.Add(data_display[i]);
        }
        _answers.Add(data_display[5]);
    }

    public void Switchart(int index)
    {

    }

    public void Grabart(int index)
    {
        _choices = data_questionSet[index].Split(',').ToList();
        _answers = data_questionSet[index + 1].Split(',').ToList();

        string question = _choices.ElementAt(0);
        _choices.RemoveAt(0);

    }

    public void Nameart(int index)
    {

    }

    public void Classifyart(int index)
    {

    }

    public void TicTacToe(int index)
    {
        _question = data_questionSet[0];
        _answers.Add(data_questionSet[1]);
    }

    public void Maze(int index)
    {
        _question = data_questionSet[0];
        _answers.Add(data_questionSet[1]);
    }

}

/* 
    Planned format when used in the GamePlay
    LoadCSV(Grabart);

    var quizLoader = new QuizLoader();
    string question = quizLoader.Question;
    list<string> choices = quizloader.Choices;
    list<string> answers = quizLoader.Answers;

    == Then assign a Question Type...
    Grabart(int index) <----- index is for rotating the question numbers

    --- BELOW HERE will eventually be the product ---

    if (choices[input] == answers)
    {
        return TRUE;
    }
    else
    {
        return FALSE;
    }

    --- CLEAR THE LIST IF THE ROUND ENDED ---

    question = null;
    choices.Clear();
    answers.Clear();
*/

