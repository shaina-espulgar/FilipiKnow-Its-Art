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
        string ipAddress = roomName.text;

        networkManager.networkAddress = ipAddress;
        networkManager.StartClient();

        joinGame.interactable = false;
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
