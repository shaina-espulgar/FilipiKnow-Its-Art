using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Class_Switchart : MonoBehaviour
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

    }

    public void Modify(string operation)
    {

    }

}
