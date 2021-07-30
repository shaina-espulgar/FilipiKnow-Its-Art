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

    // Sets the button that has formely applied by the selected color
    private Button former;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGamePlay()
    {
        downloadQuizDatabase.DownloadQuizzes();

        // test
        SceneManager.LoadScene("ScoreMenu");
    }

    public void GoToAvatarChangeScene()
    {
        SceneManager.LoadScene("AvatarMenu");
    }
   
}
