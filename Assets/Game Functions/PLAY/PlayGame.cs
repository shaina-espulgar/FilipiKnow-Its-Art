using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayGame : MonoBehaviour
{
    [Header("Download Quiz Database")]
    [SerializeField] private DownloadQuizDatabase downloadQuizDatabase;

    [Header("Number of Players")]
    [SerializeField] private Button[] playerNumber;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGamePlay()
    {
        downloadQuizDatabase.DownloadQuizzes();

        // Use this if you are now already done with the game
        // SceneManager.LoadScene("GamePlay");

        // Testing....
        SceneManager.LoadScene("ScoreMenu");
        // SceneManager.LoadScene("LeaderBoards");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }
   
}
