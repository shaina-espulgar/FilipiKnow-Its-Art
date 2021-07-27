using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_GameoverMenu : MonoBehaviour
{
    public GameObject UI_Menu_GameoverMenu;
    public GameObject Mode_Classicart_Canvas;
    public GameObject Mode_Grabart_Canvas;
    public GameObject Mode_Matchart_Canvas;
    public UI_ClasArt_QuestionTable Classicart;
    public UI_Grabart_QuestionTable Grabart;
    public UI_Matchart_QuestionTable Matchart;
    void Update()
    {
        if(Classicart.indexNumber == 3 || Grabart.indexNumber == 4) //[BAGARES] Change the value of this to an indexernumber that you want
        {
            GameOverMenuShow();
            Time.timeScale = 0f;
            Mode_Classicart_Canvas.SetActive(false);
            Mode_Grabart_Canvas.SetActive(false);
            Mode_Matchart_Canvas.SetActive(false);
            
        }
    }

    public void GameOverMenuShow()
    {
        UI_Menu_GameoverMenu.SetActive(true);
    }

    public void exitButton()
    {
        SceneManager.LoadScene("PlayGame");
    }
}