using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UI_ClasArt_QuestionTable : MonoBehaviour
{
    List<CSV_Questionnaire_Classicart> questionAnswer = new List<CSV_Questionnaire_Classicart>();

    public TextAsset Classicart;

    // Start is called before the first frame update
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
            Debug.Log(data.question);
        
        }

        
    }

    
}
