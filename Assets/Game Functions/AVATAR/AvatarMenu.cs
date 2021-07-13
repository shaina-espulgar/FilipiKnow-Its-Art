using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;

public class AvatarMenu : MonoBehaviour
{
    [SerializeField]
    private nameHandling nameHandling; //reference for the nameHandling Script


    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        transform.Find("btn_changeName").GetComponent<Button_UI>().ClickFunc = nameHandling.showInputUI;
    }
}
