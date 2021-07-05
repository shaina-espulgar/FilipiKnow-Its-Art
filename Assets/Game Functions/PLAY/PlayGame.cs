﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }
}