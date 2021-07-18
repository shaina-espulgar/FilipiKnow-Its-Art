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
    [SerializeField] private TMP_InputField input_Choices1;
    [SerializeField] private TMP_InputField input_Choices2;
    [SerializeField] private TMP_InputField input_Choices3;
    [SerializeField] private TMP_InputField input_Choices4;
    [SerializeField] private TMP_InputField input_Answer;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void QuizLoad()
    {
        string question = quizLoader.Question;
        List<string> choices = quizLoader.Choices;
        List<string> answers = quizLoader.Answers;

        input_Question.text = question;
        input_Choices1.text = choices.ElementAt(0);
        input_Choices2.text = choices.ElementAt(1);
        input_Choices3.text = choices.ElementAt(2);
        input_Choices4.text = choices.ElementAt(3);

        input_Answer.text = answers.ElementAt(0);
    }
}