using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugMessage : MonoBehaviour
{
    [Header("Debug Text")]
    [SerializeField] private TMP_Text debugText;

    int timer = 0;
    private void Start()
    {
        
    }

    void Update()
    {

    }

    public void OnIndexError()
    {
        debugText.text = "Quiz Index Error";
        timer = 0;
    }

    public void OnQuestionEmpty (string typeOfQuestion, string typeOfSubject)
    {
        debugText.text = "Question Empty in " + typeOfQuestion + " and " + typeOfSubject + " , add some.";
        timer = 0;
    }

    public void OnDownloadComplete(string typeOfQuestion)
    {
        debugText.text = typeOfQuestion + " Replaced";
        timer = 0;
    }

    public void OnUploadComplete(string typeOfQuestion)
    {
        debugText.text = typeOfQuestion + "Uploaded";
        timer = 0;
    }

    public void OnEditQuestionStatus(string typeOfQuestion)
    {
        debugText.text = "Question edited on " + typeOfQuestion;
        timer = 0;
    }

    public void OnAddQuestionStatus(string typeOfQuestion)
    {
        debugText.text = "Question added on " + typeOfQuestion;
        timer = 0;
    }

    public void OnDeleteQuestionStatus(string typeOfQuestion, string typeOfSubject)
    {
        debugText.text = "Question deleted on " + typeOfQuestion + " in " + typeOfSubject + " subject";
        timer = 0;
    }
}
