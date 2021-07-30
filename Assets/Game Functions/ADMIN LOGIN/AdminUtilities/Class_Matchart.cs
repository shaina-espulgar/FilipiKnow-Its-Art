using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Matchart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Debug Message")]
    [SerializeField] private DebugMessage debugMessage;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_Question;
    [SerializeField] private TMP_InputField[] arrChoices;

    [Header("Toggle")]
    [SerializeField] private Toggle[] arrAnswers;

    [Header("Dropdown")]
    [SerializeField] public Dropdown dropDownSubjectList;

    public void Display(bool display)
    {
        if (display == true)
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
                if (text == "FALSE")
                {
                    arrAnswers[index].isOn = false;
                }
                index++;
            }
        }
        else
        {
            return;
        }
        
    }

    public void Modify(string operation)
    {
        int index = dropDownSubjectList.value;
        string subject = dropDownSubjectList.options[index].text;

        string combineInput = string.Empty;
        string reserveInput = string.Empty;
        string combineToggle = string.Empty;
        string reserveToggle = string.Empty;

        reserveInput = input_Question.text + "|";
        for (int i = 0; i < arrChoices.Length; i++)
        {
            if (i < arrChoices.Length - 1)
            {
                combineInput = reserveInput + arrChoices[i].text + "|";
                reserveInput = combineInput;
            }
            else
            {
                combineInput = reserveInput + arrChoices[i].text;
            }

        }
        combineInput = reserveInput + "|" + subject;

        reserveToggle = "|";
        for (int i = 0; i < arrAnswers.Length; i++)
        {
            if (i < arrAnswers.Length - 1)
            {
                if (arrAnswers[i].isOn == true)
                {
                    combineToggle = reserveToggle + "TRUE|";
                    reserveToggle = combineToggle;
                }
                else
                {
                    combineToggle = reserveToggle + "|";
                    reserveToggle = combineToggle;
                }
            }
            else
            {
                if (arrAnswers[i].isOn == true) { combineToggle = reserveToggle + "TRUE"; }
                else { combineToggle = reserveToggle; }
            }
        }

        if (operation == "add")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[arrline.Length] = combineInput;
            arrline[arrline.Length + 1] = combineToggle;
            File.WriteAllLines(quizLoader.filepath, arrline);
            debugMessage.OnAddQuestionStatus(dropDownSubjectList.options[index].text);
        }

        if (operation == "edit")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[quizLoader.indexQuestion + 1] = combineInput;
            arrline[quizLoader.indexQuestion + 2] = combineToggle;
            File.WriteAllLines(quizLoader.filepath, arrline);
            debugMessage.OnEditQuestionStatus(dropDownSubjectList.options[index].text);
        }

    }

}
