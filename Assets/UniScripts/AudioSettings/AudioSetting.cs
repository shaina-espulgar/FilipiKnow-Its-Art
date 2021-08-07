using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSetting : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public List<AudioSource> soundEffectsAudio;

    private GameObject backgroundLocation;

    void Awake()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GamePlay"))
            backgroundLocation = GameObject.Find("Audio_QuizBG");
        else
            backgroundLocation = GameObject.Find("Audio_BG");

            
        if (backgroundLocation != null)
        {
            backgroundAudio = backgroundLocation.GetComponent<AudioSource>();
        }

        soundEffectsAudio.Add(GameObject.Find("Audio_Button").GetComponent<AudioSource>());

        ContinueSettings();
    }

    private void ContinueSettings()
    {
        if (backgroundAudio != null)
        {
            backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
            backgroundAudio.volume = backgroundFloat;
        }

        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        for (int i = 0; i < soundEffectsAudio.Count; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
    
}
