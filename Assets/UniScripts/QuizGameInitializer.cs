using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.PickerWheelUI;
using TMPro;

public class QuizGameInitializer : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] private GameObject quizTypePanel;
    [SerializeField] private GameObject subjectTypePanel;
    [SerializeField] private GameObject dummyDisplayQuestion;

    [Header("ToQuizTypes")]
    [SerializeField] private TMP_Text textButton;

    [Header("To Subject")]
    [SerializeField] private Sprite[] subjectSprites;
    [SerializeField] private Button subject_1;
    [SerializeField] private Button subject_2;

    [Header("PickerWheel")]
    [SerializeField] private PickerWheel pickerWheel;

    void OnEnable()
    {
        quizTypePanel.SetActive(true);

        subject_1.onClick.AddListener(delegate { ChosenSubject(subject_1.image.sprite.name); });
        subject_2.onClick.AddListener(delegate { ChosenSubject(subject_2.image.sprite.name); });
    }

    public void RandomQuiz()
    {
        if (textButton.text == "Spin")
        {
            pickerWheel.Spin();

            pickerWheel.OnSpinStart(() => {
                Debug.Log("Spin start...");
            });

            pickerWheel.OnSpinEnd(wheelPiece => {
                Debug.Log("Label  : " + wheelPiece.Label);

                SaveTypeOfQuestion(wheelPiece.Label);
                textButton.text = "Next";
            });
        }
        else if (textButton.text == "Next")
        {
            ChooseSubject();
        }
    }

    void ChooseSubject()
    {
        quizTypePanel.SetActive(false);
        subjectTypePanel.SetActive(true);

        int randomSubjectSprite_1 = Random.Range(0, subjectSprites.Length - 1);
        subject_1.image.sprite = subjectSprites[randomSubjectSprite_1];

        int randomSubjectSprite_2 = Random.Range(0, subjectSprites.Length - 1);
        if (randomSubjectSprite_2 == randomSubjectSprite_1)
        {
            randomSubjectSprite_2 = Random.Range(0, subjectSprites.Length - 1);
            subject_2.image.sprite = subjectSprites[randomSubjectSprite_2];
        }
        else
        {
            subject_2.image.sprite = subjectSprites[randomSubjectSprite_2];
        }
    }

    void ChosenSubject(string typeOfSubject)
    {
        switch (typeOfSubject)
        {
            case "National Artists":
                Debug.Log("Chosen Subject: National Artists");
                SaveTypeOfSubject(typeOfSubject, 0);
                break;

            case "GAMABA":
                Debug.Log("Chosen Subject: GAMABA");
                SaveTypeOfSubject(typeOfSubject, 1);
                break;

            case "CAFP":
                Debug.Log("Chosen Subject: CAFP");
                SaveTypeOfSubject(typeOfSubject, 2);
                break;

            case "CATPP":
                Debug.Log("Chosen Subject: CATPP");
                SaveTypeOfSubject(typeOfSubject, 3);
                break;

            case "CAP":
                Debug.Log("Chosen Subject: CAP");
                SaveTypeOfSubject(typeOfSubject, 4);
                break;
        }


        subjectTypePanel.SetActive(false);
        dummyDisplayQuestion.SetActive(true);
    }

    public static string typeOfSubject { get; private set; }
    public static int indexOfSubject { get; private set; }
    void SaveTypeOfSubject(string selectedSubject, int indexSubject)
    {
        typeOfSubject = selectedSubject;
        indexOfSubject = indexSubject;
        
    }

    public static string typeOfQuestion { get; private set; }
    void SaveTypeOfQuestion(string selectedQuestion)
    {
        typeOfQuestion = selectedQuestion;
    }
}
