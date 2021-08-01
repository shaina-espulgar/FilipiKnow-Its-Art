using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;
using TMPro;
using System;

public class DisplayHighScore : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text scoreList;

    private readonly string dbName = "URI=file:Leaderboards.db";

    void Start()
    {
        string playerName;
        if (PlayerInputName.DisplayName == null)
        {
            playerName = "Player";
        }
        else
        {
            playerName = PlayerInputName.DisplayName;
        }

        // Random random = Random.
        int score = UnityEngine.Random.Range(0, 1000);

        CreateDB();

        AddRecord(playerName, score);

        DisplayLeaderBoards();
    }

    private void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS leaderboards (playerName VARCHAR(30), score INT);";
                command.ExecuteNonQuery();
            }

            connection.Close();
        } 
    }

    private void AddRecord(string playerName, int score)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO leaderboards (playerName, score) VALUES ('" + playerName + "','" + score + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        DisplayLeaderBoards();
    }

    private void DisplayLeaderBoards()
    {
        scoreList.text = "";

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM leaderboards ORDER BY score DESC, playerName;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        scoreList.text += reader["playerName"] + "\t\t" + reader["score"] + "\n";
                    }
                    reader.Close();
                }
            }
            connection.Close();
        }
    }

    public void DeleteRecords()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DELETE FROM leaderboards";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        DisplayLeaderBoards();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
