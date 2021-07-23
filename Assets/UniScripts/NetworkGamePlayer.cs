using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkGamePlayer : NetworkBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private GameObject[] panels;
    [SerializeField] private Image[] avatars;
    [SerializeField] private TMP_Text[] avatarName;

    [SyncVar]
    private string displayName = "Loading...";
    // [SyncVar(hook = nameof(HandleAvatarProfileChanged))]
    // private string AvatarProfile;

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

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }


    // public void HandleAvatarProfileChanged(string oldValue, string newValue) => UpdateDisplay();

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
        }

        for (int i = 0; i < Game.maxConnections; i++)
        {
            panels[i].SetActive(true);
        }

        for (int i = 0; i < Game.GamePlayers.Count; i++)
        {
            
            avatarName[i].text = Game.GamePlayers[i].displayName;
            // avatars[i].sprite = Game.GamePlayers[i].AvatarProfile.sprite;
        }
    }

    // [Command]
    // private void CmdSetAvatarProfile(string avatarProfile)
    // {
    //    AvatarProfile = avatarProfile;
    // }

}
