using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class main : MonoBehaviour
{
    [SerializeField] private UI_PauseMenu PauseMenu;
    [SerializeField] private UI_Category_Handling CategoryHandle;
    [SerializeField] private UI_ClasArt_QuestionTable LoadClasArt;

    private GameObject CategoryMenu;

    private void Awake()
    {
        transform.Find("UI-Button-Pause").GetComponent<Button_UI>().ClickFunc = PauseMenu.PauseGame;
        //transform.Find("debugButton").GetComponent<Button_UI>().ClickFunc = LoadClasArt.Next;
        //LoadClasArt.displayQuestionInUI();

    }

}
