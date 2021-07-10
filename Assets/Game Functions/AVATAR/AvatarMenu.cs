using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarMenu : MonoBehaviour
{
    public nameHandling inputNameHandling;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void changeName()
    {
        //inputNameHandling.showInputUI;
    }
}
