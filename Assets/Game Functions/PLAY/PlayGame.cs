using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkLobby = null;

    [Header("Display Address")]
    [SerializeField] private Text netAddress;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }

    public void HostServer()
    {
        netAddress.text = networkLobby.networkAddress;
        networkLobby.StartHost();

    }

    // Disconnects the server if you are the host
    public void StopServer()
    {
        networkLobby.StopHost();
    }
}
