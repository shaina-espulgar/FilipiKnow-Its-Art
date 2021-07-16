using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PauseMenu : MonoBehaviour
{
    public static bool isTheGamePaused = false;
    public GameObject UI_Menu_PauseMenu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isTheGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void ResumeGame()
    {
        UI_Menu_PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isTheGamePaused = false;
    }

    public void PauseGame()
    {
        UI_Menu_PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isTheGamePaused = true;
    }

    public void ExitGame()
    {
        Debug.Log("Going back to menu...");
    }
}
