using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Classicart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;


    [Header("Inputs")]
    [SerializeField] private TMP_InputField input_Question;
    [SerializeField] private TMP_InputField[] arrChoices;
    [SerializeField] private TMP_InputField input_Answer;

    // Start is called before the first frame update

    public void Display()
    {
        string question = quizLoader.Question;
        string[] choices = quizLoader.Choices;
        string[] answers = quizLoader.Answers;

        input_Question.text = question;
        int index = 0;
        foreach (string text in choices)
        {
            arrChoices[index].text = text;
            index++;
        }
        input_Answer.text = answers[0];
    }

    public void Modify(string operation)
    {
        string combine = string.Empty;
        string reserve = string.Empty;
        string final = string.Empty;

        reserve = input_Question.text + "|";
        for (int i = 0; i < arrChoices.Length; i++)
        {
            combine = reserve + arrChoices[i].text + "|";
            reserve = combine;
        }
        final = combine + input_Answer.text;

        if (operation == "add")
        {
            quizLoader.data_questionSet = quizLoader.data_questionSet.Concat(new string[] { final }).ToArray();
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            List<string> listline = arrline.ToList();

            listline.Add(final);
            File.WriteAllLines(quizLoader.filepath, listline);
        }
        if (operation == "edit")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[quizLoader.indexQuestion + 1] = final;
            File.WriteAllLines(quizLoader.filepath, arrline);
        }

    }
}