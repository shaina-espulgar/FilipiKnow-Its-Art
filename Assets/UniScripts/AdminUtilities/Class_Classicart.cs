using System.Collections;
using System.Collections.Generic;
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
}