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

    [SyncVar(hook = nameof(HandleDisplayNameChanged))]
    private string DisplayName = "Loading...";
    // [SyncVar(hook = nameof(HandleAvatarProfileChanged))]
    // private Image AvatarProfile;

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
        // CmdSetAvatarProfile(PlayGame.AvatarProfile);

        // AvatarProfile.sprite = PlayGame.AvatarProfile;
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
        this.DisplayName = displayName;
    }

    public void HandleDisplayNameChanged(string oldValue, string newValue) => UpdateDisplay();
    public void HandleAvatarProfileChanged(Image oldValue, Image newValue) => UpdateDisplay();

    private void UpdateDisplay()
    {
        for (int i = 0; i < Game.maxConnections; i++)
        {
            panels[i].SetActive(true);
        }

        for (int i = 0; i < Game.GamePlayers.Count; i++)
        {
            avatarName[i].text = Game.GamePlayers[i].DisplayName;
            // avatars[i].sprite = Game.GamePlayers[i].AvatarProfile.sprite;
        }
    }

    // [Command]
    // private void CmdSetAvatarProfile(Sprite avatarProfile)
    // {
    //    AvatarProfile.sprite = avatarProfile;
    // }

}
