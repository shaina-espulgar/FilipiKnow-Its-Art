using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInputName : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private Button joinGame;

    public static string DisplayName { get; private set; }

    private void Start() => SetUpInputField();

    private void SetUpInputField()
    {
        string defaultName = "Player";

        playerName.text = defaultName;

        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name)  
    {   
        joinGame.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName()
    {
        DisplayName = playerName.text;
    }

}
