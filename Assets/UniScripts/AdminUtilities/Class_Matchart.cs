using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Matchart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField[] arrChoices;

    [Header("Toggle")]
    [SerializeField] private Toggle[] arrAnswers;

    public void QuizLoad()
    {
        string question = quizLoader.Question;
        string[] choices = quizLoader.Choices;
        string[] answers = quizLoader.Answers;

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
            index++;
        }
    }
}
