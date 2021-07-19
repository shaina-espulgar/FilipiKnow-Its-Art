using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

// Note: INCOMPLETE. We need to formulate a code for some of the missing questionTypes in here
public class QuizLoader : MonoBehaviour
{
    // This will load every CSV files when placed in the game
    public TextAsset[] TextAssetData;

    // Will get its specific filepath
    public string filepath = string.Empty;

    public int indexQuestion;
    public string[] data_questionSet;
    public string[] data_display;

    public void LoadCSV(string typeOfQuestion)
    {
        filepath = Application.dataPath + "/Quiz Database/" + typeOfQuestion + ".csv";

        // Transfering the CSV file into array per row
        data_questionSet = File.ReadAllLines(filepath);

        // Deleting the first row of the referenced CSV
        for (int i = 0; i < data_questionSet.Length - 1; i++)
        {
            data_questionSet[i] = data_questionSet[i + 1];
        }
        Array.Resize(ref data_questionSet, data_questionSet.Length - 1);

        // Spliting the data_questionSet into columns or pieces
        data_display = data_questionSet[indexQuestion].Split(new string[] { "|" }, StringSplitOptions.None);

        switch (typeOfQuestion)
        {
            case "Classicart": Classicart(); break;
            case "Matchart": Matchart(indexQuestion); break;
            case "Switchart": Switchart(); break;
            case "Grabart": Grabart(indexQuestion); break;
            case "Nameart": Nameart(); break;
            case "Classifyart": Classifyart(); break;
            case "TicTacToe": TicTacToe(); break;
            case "Maze": Maze(); break;
        }
    }

    // Use Getter and Setter so we can get the variable of these stuffs or modify it even from the outside
    private string _question;
    public string Question
    {
        get { return _question; }
        set { _question = value; }
    }

    public int choicesLength;
    private string[] _choices;
    public string[] Choices
    {   
        get { return _choices; }
        set { _choices = value; }
    }

    public int answersLength;
    private string[] _answers;
    public string[] Answers
    {
        get { return _answers; }
        set { _answers = value; }
    }

    // private void Initialize()
    // {
    //    _choices = new string[choicesLength];
    //    _answers = new string[answersLength];
    // }

    public void Classicart()
    {
        choicesLength = 4; answersLength = 1;
        _choices = new string[choicesLength];
        _answers = new string[answersLength];

        _question = data_display[0];
        for (int i = 1; i <= choicesLength ; i++)
        {
            _choices[i - 1] = data_display[i];
        }
        _answers[0] = data_display[5];
    }

    public void Matchart(int index)
    {
        // These three first lines were redundant anyway but Im trying to come up with an alternative
        // choicesLength = 6; answersLength = 6;
        // _choices = new string[choicesLength];
        // _answers = new string[answersLength];

        _choices = data_questionSet[index].Split('|');
        _answers = data_questionSet[index + 1].Split('|');
        _question = _choices[0];

        // Decrease the size of an array by 1 (first column) since that column is composed of a question with corresponding empty block below it as always 
        for (int i = 0; i < _choices.Length - 1; i++)
        {
            _choices[i] = _choices[i + 1];
            _answers[i] = _answers[i + 1];
        }
        Array.Resize(ref _choices, _choices.Length - 1);
        Array.Resize(ref _answers, _answers.Length - 1);
    }

    public void Switchart()
    {

    }

    public void Grabart(int index)
    {
        // These three first lines were redundant anyway but Im trying to come up with an alternative
        // choicesLength = 15; answersLength = 15;
        // _choices = new string[choicesLength];
        // _answers = new string[answersLength];

        _choices = data_questionSet[index].Split('|');
        _answers = data_questionSet[index + 1].Split('|');
        _question = _choices[0];

        // Decrease the size of an array by 1 (first column) since that column is composed of a question with corresponding empty block below it as always
        for (int i = 0; i < _choices.Length - 1; i++)
        {
            _choices[i] = _choices[i + 1];
            _answers[i] = _answers[i + 1];
        }
        Array.Resize(ref _choices, _choices.Length - 1);
        Array.Resize(ref _answers, _answers.Length - 1);
    }

    public void Nameart()
    {

    }

    public void Classifyart()
    {

    }

    public void TicTacToe()
    {
        _question = data_display[0];
        _answers[0] = data_display[1];
    }

    public void Maze()
    {
        _question = data_display[0];
        _answers[0] = data_display[1];
    }
}

/* 
    Planned format when used in the GamePlay

    [SerializeField] private QuizLoader quizLoader;

    void Start()
    {
        string question = quizLoader.Question;
        list<string> choices = quizloader.Choices;
        list<string> answers = quizLoader.Answers;
        
        == Then assign a Question Type...
        quizLoader.LoadCSV("Grabart");
    }

    --- BELOW HERE will eventually be the product ---
    void Game()
    {
        if (choices[input] == answers)
        {
            return TRUE;
        }
        else
        {
            return FALSE;
        }
    }

    void Previous()
    {
        quizLoader.indexQuestion--;
        
        -- If it is Grabart or Matchart we will decrement the indexQuestion by 2 since each questions consume 2 rows in there.
    }

    void Next()
    {
        quizLoader.indexQuestion++;

        -- If it is Grabart or Matchart we will increment the indexQuestion by 2 since each questions consume 2 rows in there.
    }

    -- Need some code for not overpassing the value of indexQuestion to the no. of questions

    void Clear()
    {
        --- CLEAR THE LIST IF THE ROUND ENDED 
        --- However this part is just my theory that the code will not erase the former values of these.
        question = null;
        choices.Clear();
        answers.Clear();
    }
*/

