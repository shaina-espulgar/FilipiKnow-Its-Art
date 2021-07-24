using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NetworkGamePlayer : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private GameObject[] panels;

    // Avatar Images referring to the set of avatar pictures placed in GAME FUNCTIONS/AVATARS
    [SerializeField] private Sprite[] avatarImages;
    // This will be the resulted view of a selected avatarImages coming from PlayGame into this scene
    [SerializeField] private Image[] avatars;

    [SerializeField] private TMP_Text[] avatarName;

    [SyncVar]
    private string displayName = "Loading...";
    [SyncVar]
    private int avatarProfileIndex = 0;
    // Player Score Here
    // [SyncVar(hook = nameof(HandleScoreRecordChanged))
    // public int PlayerScores

    private NetworkManagerLobby game;
    private NetworkManagerLobby Game
    {
        get
        {
            if (game != null) { return game; }
            return game = NetworkManager.singleton as NetworkManagerLobby;
        }
    }

    public override void OnStartAuthority()
    {
        lobbyUI.SetActive(true);
    }

    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);

        Game.GamePlayers.Add(this);

        UpdateDisplay();
    }

    public override void OnStopClient()
    {
        Game.GamePlayers.Remove(this);

        UpdateDisplay();
    }

    public override void OnStopServer()
    {
        Game.StopClient();

        SceneManager.LoadScene("PlayGame");
    }

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }

    [Server]
    public void SetAvatarProfile(int avatarProfileIndex)
    {
        this.avatarProfileIndex = avatarProfileIndex;
    }

    private void UpdateDisplay()
    {
        if (!hasAuthority)
        {
            foreach (var player in Game.GamePlayers)
            {
                if (player.hasAuthority)
                {
                    player.UpdateDisplay();
                    break;
                }
            }

            return;
        }

        for (int i = 0; i < Game.maxConnections; i++)
        {
            panels[i].SetActive(true);
        }

        for (int i = 0; i < Game.GamePlayers.Count; i++)
        {
            avatars[i].sprite = Game.GamePlayers[i].avatarImages[avatarProfileIndex];
            avatarName[i].text = Game.GamePlayers[i].displayName;

        }
    }


}
