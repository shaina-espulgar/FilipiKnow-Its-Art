using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//HOPE THAT IT WILL NOT REMOVED

public class nameHandling : MonoBehaviour
{
    public string nameOfPlayer;
    public string DEFAULT_NAME;
    public Text playerNameShowUI;

    public void nameDefaultRandomization()
    {
        string[] DEFAULT_NAMES_INDEX = { "Aron", "Rapiest", "Terrier", "Nosferatu" };
        DEFAULT_NAME = DEFAULT_NAMES_INDEX[Random.Range(0, DEFAULT_NAMES_INDEX.Length - 1)];
    }

    void Start()
    {
        nameDefaultRandomization();
        Debug.Log(DEFAULT_NAME + " is your name");
    }

    
}
