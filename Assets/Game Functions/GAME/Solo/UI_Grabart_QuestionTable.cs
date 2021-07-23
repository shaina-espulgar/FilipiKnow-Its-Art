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


    [SerializeField] private Button choiceAButton; public TextMeshProUGUI choiceA;
    [SerializeField] private Button choiceBButton; public TextMeshProUGUI choiceB;
    [SerializeField] private Button choiceCButton; public TextMeshProUGUI choiceC;
    [SerializeField] private Button choiceDButton; public TextMeshProUGUI choiceD;
    [SerializeField] private Button choiceEButton; public TextMeshProUGUI choiceE;
    [SerializeField] private Button choiceFButton; public TextMeshProUGUI choiceF;
    [SerializeField] private Button choiceGButton; public TextMeshProUGUI choiceG;
    [SerializeField] private Button choiceHButton; public TextMeshProUGUI choiceH;
    [SerializeField] private Button choiceIButton; public TextMeshProUGUI choiceI;
    [SerializeField] private Button choiceJButton; public TextMeshProUGUI choiceJ;
    [SerializeField] private Button choiceKButton; public TextMeshProUGUI choiceK;
    [SerializeField] private Button choiceLButton; public TextMeshProUGUI choiceL;


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
            else if (i == 4)
            {
                choiceE.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 5)
            {
                choiceF.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 6)
            {
                choiceG.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 7)
            {
                choiceH.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 8)
            {
                choiceI.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 9)
            {
                choiceJ.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 10)
            {
                choiceK.text = choices[i];
                //Debug.Log(i + " is choice B");
            }
            else if (i == 11)
            {
                choiceL.text = choices[i];
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
    public void choiceButtonE_Input()
    {
        Debug.Log("Choice E");
    }
    public void choiceButtonF_Input()
    {
        Debug.Log("Choice F");
    }
    public void choiceButtonG_Input()
    {
        Debug.Log("Choice G");
    }
    public void choiceButtonH_Input()
    {
        Debug.Log("Choice H");
    }
    public void choiceButtonI_Input()
    {
        Debug.Log("Choice I");
    }
    public void choiceButtonJ_Input()
    {
        Debug.Log("Choice J");
    }
    public void choiceButtonK_Input()
    {
        Debug.Log("Choice K");
    }
    public void choiceButtonL_Input()
    {
        Debug.Log("Choice L");
    }
}
