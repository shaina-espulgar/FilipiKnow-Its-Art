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

    [Header("Avatar Images")]
    [SerializeField] private Image selectedAvatar;
    [SerializeField] private Sprite[] avatarImage;
    private int avatarIndex = 0;

    [Header("Button Colors")]
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color defaultColor;



    // Sets the button that has formely applied by the selected color
    private Button former;

    // The default settings for the number of players allowed to play in the game
    private int numberOfPlayers = 4;

    public void Start()
    {
        playerNumber[playerNumber.Length - 1].image.color = selectedColor;
        former = playerNumber[playerNumber.Length - 1];
    }

    public void ReturnToMainMenu()
    {
        Destroy(GameObject.Find("Network Manager"));
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }

    // Creates a server with a defined network address and its maximum allowed connections
    public void HostServer()
    {
        networkLobby.StartHost();
        if (string.IsNullOrEmpty(editAddress.text))
        {
            string[] rooms = { "GameLobby", "GGhaveFun", "EnjoyTheGame", "PlayNice"};
            networkLobby.networkAddress = rooms[Random.Range(0, rooms.Length - 1)];
        }
        else
        {
            networkLobby.networkAddress = editAddress.text;
        }
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

        former.image.color = defaultColor;
        playerNumber[number - 1].image.color = selectedColor;
        former = playerNumber[number - 1];
    }
    
    // To be separated to the Player Avatar Profile soon!!

    public static string AvatarProfile { get; private set; }

    public void PreviousAvatar()
    {
        avatarIndex--;
        if (avatarIndex < 0)
        {
            avatarIndex = avatarImage.Length - 1;
        }
        selectedAvatar.sprite = avatarImage[avatarIndex];
    }

    public void NextAvatar()
    {
        avatarIndex++;
        if (avatarIndex > avatarImage.Length - 1)
        {
            avatarIndex = 0;
        }
        selectedAvatar.sprite = avatarImage[avatarIndex];
    }

    public void SaveAvatarProfile()
    {
        AvatarProfile = avatarImage[avatarIndex].name;
    }
}
