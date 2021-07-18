using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Class_Grabart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_Question;
    [SerializeField] private TMP_InputField[] arrChoices;

    [Header("Toggle")]
    [SerializeField] private Toggle[] arrAnswers;

    public void Display()
    {
        string question = quizLoader.Question;
        string[] choices = quizLoader.Choices;
        string[] answers = quizLoader.Answers;

        input_Question.text = question;
        for (int i = 0; i < answers.Length - 1; i++)
        {
            answers[i] = answers[i + 1];
        }
        Array.Resize(ref answers, answers.Length - 1);

        int index = 0;
        foreach (string text in choices)
        {
            arrChoices[index].text = text;
            index++;
        }

        index = 0;
        foreach (string text in answers)
        {
            if (text == "TRUE")
            {
                arrAnswers[index].isOn = true;
            }
            else
            {
                arrAnswers[index].isOn = false;
            }
            index++;
        }
    }

    public void Modify(string operation)
    {
        string combineInput = string.Empty;
        string reserveInput = string.Empty;
        string combineToggle = string.Empty;
        string reserveToggle = string.Empty;

        reserveInput = input_Question.text + ",";
        for (int i = 0; i < arrChoices.Length; i++)
        {
            if (i < arrChoices.Length - 1)
            {
                combineInput = reserveInput + arrChoices[i].text + ",";
                reserveInput = combineInput;
            }
            else
            {
                combineInput = reserveInput + arrChoices[i].text;
            }

        }

        reserveToggle = ",";
        for (int i = 0; i < arrAnswers.Length; i++)
        {
            if (i < arrAnswers.Length - 1)
            {
                if (arrAnswers[i].isOn == true)
                {
                    combineToggle = reserveToggle + "TRUE,";
                    reserveToggle = combineToggle;
                }
                else
                {
                    combineToggle = reserveToggle + ",";
                    reserveToggle = combineToggle;
                }
            }
            else
            {
                if (arrAnswers[i].isOn == true) { combineToggle = reserveToggle + "TRUE";}
                else { combineToggle = reserveToggle; }
            }
        }

        if (operation == "add")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            List<string> listline = arrline.ToList();

            listline.Add(combineInput);
            listline.Add(combineToggle);
            File.WriteAllLines(quizLoader.filepath, listline);
        }
        if(operation == "edit")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[quizLoader.indexQuestion + 1] = combineInput;
            arrline[quizLoader.indexQuestion + 2] = combineToggle;
            File.WriteAllLines(quizLoader.filepath, arrline);
        }
    }
}
