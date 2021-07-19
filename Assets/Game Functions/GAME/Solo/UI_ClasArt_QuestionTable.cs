using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using CodeMonkey.Utils;

public class UI_ClasArt_QuestionTable : MonoBehaviour
{
    //[BAGARES] Old code for test purpose
    /* This handles the Classicart Game Mode in which players will choose upon Round 1
     *  It is a basic question and answer portion in which the players will choose 1 answer in a multiple choice question
     * 
     
    List<CSV_Questionnaire_Classicart> questionAnswer = new List<CSV_Questionnaire_Classicart>();

    //References
    public TextAsset Classicart; //[BAGARES] Variable to Reference a CSV file Classicart (through Unity)
    [SerializeField] private QuizLoader Quizloader; //[BAGARES] Reference from Quizloader
    public int classicartQCount; //[BAGARES] Will determine how many numbers are there now being displayed

    public string stringX; //[BAGARES] for debugging

    public TextMeshProUGUI QuestionText; //[BAGARES] Reference for the Text in QUestion UI

    void Start()
    {

        string[] questionAndAnswer = Classicart.text.Split(new char[]{'\n' });

        for (int i = 1; i < questionAndAnswer.Length - 1; i++ )
        {
            string[] rowTable = questionAndAnswer[i].Split(new char[] { ',' });

            CSV_Questionnaire_Classicart data = new CSV_Questionnaire_Classicart();
            data.question = rowTable[0];
            data.choice_a = rowTable[1];
            data.choice_b = rowTable[2];
            data.choice_c = rowTable[3];
            data.choice_d = rowTable[4];
            data.correct_answer = rowTable[5];

            questionAnswer.Add(data);
        }
        foreach (CSV_Questionnaire_Classicart data in questionAnswer)
        {

            Debug.Log(data.id + " ." + data.question); 
        
        }
        
    }


    public void displayQuestionInUI()
    {
        /*
         * [BAGARES] used For Debugging
        stringX = "HEllo"; 
        QuestionText.text = stringX;
   
    }*/


    [SerializeField] private QuizLoader quizLoader;

    string question; //{BAGARES] MAybe reference for an array of questions, answers and choices saved in Quizloader.cs
    string[] choices;
    string[] answers;

    private Button_UI choiceAButton; //These are variables for referencing for choices ABCD 
    private Button_UI choiceBButton;
    private Button_UI choiceCButton;
    private Button_UI choiceDButton;

    public TextMeshProUGUI choiceA;
    public TextMeshProUGUI choiceB;
    public TextMeshProUGUI choiceC;
    public TextMeshProUGUI choiceD;

    public string input; //For input Players


    void Start()
    {
        
        //== Then assign a Question Type...
        quizLoader.LoadCSV("Classicart");

        choices = quizLoader.Choices;
        answers = quizLoader.Answers;

        for(int i = 0; i != choices.Length; i++) //For showing the text asset from text Meshes in choice UI
        {
            if(i == 0)
            {
                choiceA.text = choices[i];
                Debug.Log(i + " is choice A");
            }
            else if(i==1)
            {
                choiceB.text = choices[i];
                Debug.Log(i + " is choice B");
            }
            else if (i == 2)
            {
                choiceC.text = choices[i];
                Debug.Log(i + " is choice Bc");
            }
            else if (i == 3)
            {
                choiceD.text = choices[i];
                Debug.Log(i + " is choice B");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }

      
    }


    //--- BELOW HERE will eventually be the product ---
    void Game()
    {
        /*if (choices[input] == answers)
        {
            return true;
        }
        else
        {
            return false;
        }*/
    }

    void Previous()
    {
        quizLoader.indexQuestion--;
    }

    void Next()
    {
        quizLoader.indexQuestion++;
    }

    //-- Need some code for not overpassing the value of indexQuestion to the no.of questions

    void Clear()
    {
        //---CLEAR THE LIST IF THE ROUND ENDED ---
        question = null;
        Array.Clear(choices, 0, choices.Length);
        Array.Clear(answers, 0, answers.Length);
    }


}

