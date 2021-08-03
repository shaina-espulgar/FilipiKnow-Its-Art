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

    [Header("ToQuizTypes")]
    [SerializeField] private TMP_Text textButton;

    [Header("To Subject")]
    [SerializeField] private Sprite[] subjectSprites;
    [SerializeField] private Button subject_1;
    [SerializeField] private Button subject_2;

    [Header("PickerWheel")]
    [SerializeField] private PickerWheel pickerWheel;

    // Start is called before the first frame update
    void Start()
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
                break;

            case "GAMABA":
                Debug.Log("Chosen Subject: GAMABA");
                break;

            case "CAFP":
                Debug.Log("Chosen Subject: CAFP");
                break;

            case "CATPP":
                Debug.Log("Chosen Subject: CATPP");
                break;

            case "CAP":
                Debug.Log("Chosen Subject: CAP");
                break;
        }
    }
}
