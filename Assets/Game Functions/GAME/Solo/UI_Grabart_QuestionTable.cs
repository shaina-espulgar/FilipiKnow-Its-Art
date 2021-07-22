using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UI_Grabart_QuestionTable : MonoBehaviour
{
    [SerializeField] private QuizLoader quizLoader;

    string question; //{BAGARES] MAybe reference for an array of questions, answers and choices saved in Quizloader.cs
    string[] choices;
    string[] answers;


    [SerializeField] private Button choiceAButton;
    [SerializeField] private Button choiceBButton;
    [SerializeField] private Button choiceCButton;
    [SerializeField] private Button choiceDButton;

    public TextMeshProUGUI choiceA;
    public TextMeshProUGUI choiceB;
    public TextMeshProUGUI choiceC;
    public TextMeshProUGUI choiceD;

    public string input; //For input Players
    public int number;
    public TextMeshProUGUI QuestionText; //[BAGARES] Reference for the Text in QUestion UI


    void Start()
    {

    }


    //--- BELOW HERE will eventually be the product ---
    void Update()
    {
        //== Then assign a Question Type...
        quizLoader.LoadCSV("Grabart", "National Artist");

        choices = quizLoader.Choices;
        answers = quizLoader.Answers;
        question = quizLoader.Question;

        showTextInQuestionUI();
        showTextInChoiceUI();



    }

    void Previous()
    {
        quizLoader.indexQuestion--;
    }

    public void Next()
    {
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;

        number += 1;
        quizLoader.indexQuestion = number;

    }

    //-- Need some code for not overpassing the value of indexQuestion to the no.of questions

    void Clear()
    {
        //---CLEAR THE LIST IF THE ROUND ENDED ---
        question = null;
        Array.Clear(choices, 0, choices.Length);
        Array.Clear(answers, 0, answers.Length);
    }

    void showTextInChoiceUI()
    {
        for (int i = 0; i != choices.Length; i++) //For showing the text asset from text Meshes in choice UI
        {
            if (i == 0)
            {
                choiceA.text = choices[i];
                //Debug.Log(i + " is choice A");
            }
            else if (i == 1)
            {
                choiceB.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 2)
            {
                choiceC.text = choices[i];
                //Debug.Log(i + " is choice Bc");
            }
            else if (i == 3)
            {
                choiceD.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else
            {
                Debug.Log("ERROR");
            }
        }
    }

    void showTextInQuestionUI()
    {
        QuestionText.text = question;
    }

    public void choiceButtonA_Input()
    {
        input = choiceA.text;
        Debug.Log("Choice A: " + input);
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
    }
    public void choiceButtonB_Input()
    {
        Debug.Log("Choice B");
    }
    public void choiceButtonC_Input()
    {
        Debug.Log("Choice C");
    }
    public void choiceButtonD_Input()
    {
        Debug.Log("Choice D");
    }
}
