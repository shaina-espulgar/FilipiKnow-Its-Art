using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UI_ClasArt_QuestionTable : MonoBehaviour
{
    /* This handles the Classicart Game Mode in which players will choose upon Round 1
     *  It is a basic question and answer portion in which the players will choose 1 answer in a multiple choice question
     * 
     */
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
            int.TryParse(rowTable[0], out data.id);
            data.question = rowTable[1];
            data.choice_a = rowTable[2];
            data.choice_b = rowTable[3];
            data.choice_c = rowTable[4];
            data.choice_d = rowTable[5];
            data.correct_answer = rowTable[6];

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
        */

        


   
    }

    
}
