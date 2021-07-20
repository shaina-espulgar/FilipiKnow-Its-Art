using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Classifyart : MonoBehaviour
{
    [Header("QuizLoader")]
    [SerializeField] private QuizLoader quizLoader;

    [Header("Dropdowns")]
    [SerializeField] private TMP_Dropdown[] subjectDrop;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField[] arrChoices;

    public void Display(bool display)
    {
        /*
        if (display == true)
        {
            string[] answers = quizLoader.Answers;
            string[] choices = quizLoader.Choices;

            for (int i = 0; i < subjectDrop.Length; i++)
            {
                subjectDrop[i].value = subjectDrop[i].options.FindIndex(option => option.text == answers[0]);
            }

            for (int i = 0; i < arrChoices.Length; i++)
            {
                arrChoices[i].text = choices[i];
            }
        }
        else
        {
            return;
        }
        */
    }

    public void Modify(string operation)
    {
        string final = string.Empty;

        int index;
        for (int i = 0; i < arrChoices.Length; i++)
        {
            final = final + arrChoices[i];
            if (i == 1 || i == 3)
            {
                index = 0;
                final = final + subjectDrop[i].options[index].text;
                index++;
            }
        }

        if (operation == "add")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline = arrline.Concat(new string[] { final }).ToArray();
            File.WriteAllLines(quizLoader.filepath, arrline);
        }
        if (operation == "edit")
        {
            string[] arrline = File.ReadAllLines(quizLoader.filepath);
            arrline[quizLoader.indexQuestion + 1] = final;
            File.WriteAllLines(quizLoader.filepath, arrline);
        }
    }
}
