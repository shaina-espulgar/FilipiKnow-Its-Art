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
    [SerializeField] private NetworkManagerLobby networkLobby;

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
}
