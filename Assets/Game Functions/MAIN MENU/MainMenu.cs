using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void AdminMenu()
    {
        SceneManager.LoadScene("AdminMenu");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void AvatarMenu()
    {
        SceneManager.LoadScene("AvatarMenu");
    }

    public void AboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
