using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the GameObjects to be used even when its on DontDestroyOnLoad
public class AudioPlay : MonoBehaviour
{
    private AudioSource buttonAudio;
    private AudioSource soundWinning;
    private AudioSource soundLosing;
    private AudioSource soundTimer;
    private AudioSource soundTimesUp;

    private GameObject buttonAudioLocation;
    private GameObject soundWinningLocation;
    private GameObject soundLosingLocation;
    private GameObject soundTimerLocation;
    private GameObject soundTimesUpLocation;

    private void Start()
    {
        buttonAudioLocation = GameObject.Find("Audio_Button");
        if (buttonAudioLocation != null)
            buttonAudio = buttonAudioLocation.GetComponent<AudioSource>();

        soundWinningLocation = GameObject.Find("Audio_Winning");
        if (soundWinningLocation != null)
            soundWinning = soundWinningLocation.GetComponent<AudioSource>();

        soundLosingLocation = GameObject.Find("Audio_Losing");
        if (soundLosingLocation != null)
            soundLosing = soundLosingLocation.GetComponent<AudioSource>();

        soundTimerLocation = GameObject.Find("Audio_Timer");
        if (soundTimerLocation != null)
            soundTimer = soundTimerLocation.GetComponent<AudioSource>();

        soundTimesUpLocation = GameObject.Find("Audio_TimesUp");
        if (soundTimesUpLocation != null)
            soundTimesUp = soundTimesUpLocation.GetComponent<AudioSource>();
    }

    public void ButtonAudio()
    {
        buttonAudio.Play();
    }

    public void AudioLose()
    {
        soundLosing.Play();
    }

    public void AudioWin()
    {
        soundWinning.Play();
    }

    public void AudioTimer(string response)
    {
        switch (response)
        {
            case "play":
                soundTimer.Play();
                break;

            case "stop":
                soundTimer.Stop();
                break;

            default:
                Debug.Log("Invalid Input");
                break;
        }

    }

    public void AudioTimesUp()
    {
        soundTimesUp.Play();
    }
}
