using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_TicTacToe : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_Question;

    [Header("Toggle")]
    [SerializeField] private Toggle toggle_True;
    [SerializeField] private Toggle toggle_False;

    public void Display()
    {
        string question = quizLoader.Question;
        string[] choices = quizLoader.Choices;
        string[] answers = quizLoader.Answers;

        input_Question.text = question;
        if (answers[0] == "TRUE")
        {
            toggle_True.isOn = true;
            toggle_False.isOn = false;
        }
        else
        {
            toggle_False.isOn = true;
            toggle_True.isOn = false;

        }
    }

    public void Modify(string operation)
    {
        string final = string.Empty;
        string combine = string.Empty;

        combine = input_Question.text + "|";
        if (toggle_True.isOn == true)
        {
            final = combine + "TRUE";
        }
        if (toggle_False.isOn == true)
        {
            final = combine + "FALSE";
        }

        if(operation == "add")
        {
            quizLoader.data_questionSet = quizLoader.data_questionSet.Concat(new string[] { final }).ToArray();
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            List<string> listline = arrline.ToList();

            listline.Add(final);
            File.WriteAllLines(quizLoader.filepath, listline);
        }
        if(operation == "edit")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[quizLoader.indexQuestion + 1] = final;
            File.WriteAllLines(quizLoader.filepath, arrline);
        }
    }
}
