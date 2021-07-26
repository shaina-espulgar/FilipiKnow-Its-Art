using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Networking;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class UploadQuizDatabaseOld : MonoBehaviour
{
    [SerializeField] private TMP_InputField testing;
    [SerializeField] private Button submit;
    [SerializeField] private Text display;

    public void Add()
    {
        SendToServer("Classicart", testing.text);
    }

    public void SendToServer(string questionType, string addedRow)
    {
        switch (questionType)
        {
            case "Classicart": StartCoroutine(SendToClassicart(addedRow)); break;
            // case "Matchart": ; break;
            // case "Switchart": ; break;
            // case "Grabart": Panel_Grabart(); break;
            // case "Classifyart": Panel_Classifyart(); break;
            // case "TicTacToe": Panel_TicTacToe(); break;
            // case "Maze": Panel_Maze(); break;
            default: return;
        }
    }

    IEnumerator SendToClassicart(string addedRow)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.257186560", addedRow);

        display.text = form.data.ToString();

        // string rawData = form.data.ToString();
        // UnityWebRequest newRow = new UnityWebRequest("https://docs.google.com/forms/u/0/d/e/1FAIpQLSeydJL5xW16lsQEdJwd1rn1CLP6NH8u-A4bBcaizb9sbeBExg/formResponse", rawData);

        byte[] rawData = form.data;
        WWW www = new WWW("https://docs.google.com/forms/u/0/d/e/1FAIpQLSeydJL5xW16lsQEdJwd1rn1CLP6NH8u-A4bBcaizb9sbeBExg/formResponse", rawData);
        Debug.Log("Question Added");

        yield return www;
    }   
}
