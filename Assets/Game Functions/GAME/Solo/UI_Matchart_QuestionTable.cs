using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UI_Matchart_QuestionTable : MonoBehaviour
{
    [Header("QuizLoader")] 
    [SerializeField] private QuizLoader quizLoader;
    [SerializeField] TextMeshProUGUI UI_CountDown; //[BAGARES] UI Object for the timer

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


    public string firstInput; //[BAGARES] Since MAtchart is a game that will match two words related, we need 2 variables for the input
    public string secondInput;
    bool isAtSecondOption;

    public int indexNumber;

    float currentTime = 0f; //[BAGARES] float var, for the Timer 
    float startingTime = 10f;


    void Start()
    {
        isAtSecondOption = false;
        currentTime = startingTime;
        UI_changeToWhiteButton();
    }


    //--- BELOW HERE will eventually be the product ---
    void Update()
    {
        //== Then assign a Question Type...
        quizLoader.LoadCSV("Matchart", "National Artist");

        choices = quizLoader.Choices;
        answers = quizLoader.Answers;
        question = quizLoader.Question;

        showTextInChoiceUI();

        UI_Timer(); // Shows the UI for the Timer
        Next();

    }

    void Previous()
    {
        quizLoader.indexQuestion--;
    }

    public void Next()
    {

        if (currentTime == 0)
        {

            disableEnableButton();
            Debug.Log("Buttons are now set to interactable");
            UI_changeToWhiteButton();

            isAtSecondOption = false;
            indexNumber += 1;
            quizLoader.indexQuestion = indexNumber;

            currentTime = startingTime;
        }

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
            else
            {
                Debug.Log("ERROR");
            }
        }
    }


    public void choiceButtonA_Input()
    {
        if(isAtSecondOption == false)
        {
            firstInput = choiceA.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceA.text;
            disableEnableButton();

        }
        
        

    }
    public void choiceButtonB_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceB.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceB.text;
            disableEnableButton();

        }
    }
    public void choiceButtonC_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceC.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceC.text;
            disableEnableButton();

        }
    }
    public void choiceButtonD_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceD.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceD.text;
            disableEnableButton();

        }
    }
    public void choiceButtonE_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceE.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceE.text;
            disableEnableButton();

        }
    }
    public void choiceButtonF_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceF.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceF.text;
            disableEnableButton();

        }
    }
    public void choiceButtonG_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceG.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceG.text;
            disableEnableButton();

        }
    }
    public void choiceButtonH_Input()
    {
        if (isAtSecondOption == false)
        {
            firstInput = choiceH.text;
            isAtSecondOption = true;
            Debug.Log("Choice _, selected. Choose one more option");
        }
        else
        {
            secondInput = choiceH.text;
            disableEnableButton();

        }
    }

    void UI_changeToWhiteButton()
    {
        choiceAButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceBButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceCButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceDButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceEButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceFButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceGButton.image.color = new Color(1f, 1f, 1f, 0.22f);
        choiceHButton.image.color = new Color(1f, 1f, 1f, 0.22f);

    }

    void UI_Timer() //[BAGARES] Function for the UI Timer in game (some errors exist when in separate script)
    {
        currentTime -= 1 * Time.deltaTime;
        UI_CountDown.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    void disableEnableButton()
    {
        choiceAButton.interactable = !choiceAButton.interactable;
        choiceBButton.interactable = !choiceBButton.interactable;
        choiceCButton.interactable = !choiceCButton.interactable;
        choiceDButton.interactable = !choiceDButton.interactable;
        choiceEButton.interactable = !choiceEButton.interactable;
        choiceFButton.interactable = !choiceFButton.interactable;
        choiceGButton.interactable = !choiceGButton.interactable;
        choiceHButton.interactable = !choiceHButton.interactable;

    }
}
