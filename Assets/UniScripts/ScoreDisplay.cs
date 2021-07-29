using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMP_Text txt_Congratulations;
    [SerializeField] private TMP_Text txt_Score;

    [Header("Avatar")]
    [SerializeField] private Image image_Avatar;
    [SerializeField] private Sprite[] sprite_Avatar;

    // Start is called before the first frame update
    void Start()
    {
        CurrentName(PlayerInputName.DisplayName);
        CurrentAvatar(AvatarDisplay.AvatarProfileIndex);
        // CurrentScore();
    }

    void CurrentName(string name)
    {
        txt_Congratulations.text = "Congratulations," + name;
    }

    void CurrentAvatar(int index)
    {
        image_Avatar.sprite = sprite_Avatar[index];
    }

    void CurrentScore(int score)
    {

    }
}
