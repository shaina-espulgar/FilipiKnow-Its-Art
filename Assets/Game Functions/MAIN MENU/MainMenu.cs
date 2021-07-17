using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject canvas;
    public void Start()
    {
        DefaultControls.Resources uiResources = new DefaultControls.Resources();
        //Set the InputField Background Image someBgSprite;

        GameObject uiInputField = DefaultControls.CreateInputField(uiResources);
        uiInputField.transform.SetParent(canvas.transform, false);
        uiInputField.transform.position = new Vector3(100, 100, 100);
        uiInputField.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 200);
        uiInputField.transform.GetChild(0).GetComponent<Text>().font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

    }
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
