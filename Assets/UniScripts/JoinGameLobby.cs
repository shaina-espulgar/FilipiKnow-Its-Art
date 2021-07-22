using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinGameLobby : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager;

    [Header("UI")]
    [SerializeField] private TMP_InputField roomName = null;
    [SerializeField] private Button joinGame = null;

    private void OnEnable()
    {
        NetworkManagerLobby.OnClientConnected += HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        NetworkManagerLobby.OnClientConnected -= HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected -= HandleClientDisconnected;
    }

    public void JoinLobby()
    {
        try
        {
            string ipAddress = roomName.text;

            networkManager.networkAddress = ipAddress;
            networkManager.StartClient();

            joinGame.interactable = false;
        }

        // Pls help me find what kind of exception will happen if a player joined on a full room
        catch (KeyNotFoundException) // Dummy exception
        {

        }

    }

    private void HandleClientConnected()
    {
        joinGame.interactable = true;

        gameObject.SetActive(false);
    }

    private void HandleClientDisconnected()
    {
        joinGame.interactable = true;
    }
}
