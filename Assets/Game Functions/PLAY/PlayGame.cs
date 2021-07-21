using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkLobby;
    [SerializeField] private TMP_InputField editAddress;

    [Header("Number of Players")]
    [SerializeField] private Button[] playerNumber;

    [Header("Button Colors")]
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color defaultColor;

    private int numberOfPlayers = 4;

    public void ReturnToMainMenu()
    {
        GameObject.Destroy(GameObject.Find("Network Manager"));
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }

    public void HostServer()
    {
        networkLobby.StartHost();
        networkLobby.networkAddress = editAddress.text;
        networkLobby.maxConnections = numberOfPlayers;
    }

    // Disconnects the server if you are the host
    public void StopServer()
    {
        networkLobby.StopHost();
    }

    public void StopClient()
    {
        networkLobby.StopClient();
    }

    public void ToggleNumberPlayers(int number)
    {
        switch (number)
        {
            case 1: numberOfPlayers = 1; break;
            case 2: numberOfPlayers = 2; break;
            case 3: numberOfPlayers = 3; break;
            case 4: numberOfPlayers = 4; break;
        }

    }       
}
