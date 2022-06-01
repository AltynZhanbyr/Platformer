using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuWindow;

    public Slider MusicVolume;

    public SlowTimeScript TimeScript;
    public MonoBehaviour[] Shot;

    public AudioSource Audio;

    private void Start()
    {
        MusicVolume.value = Audio.volume;
    }
    public void OnWindowDisabled() 
    {
        MenuButton.SetActive(true);
        MenuWindow.SetActive(false);
        Time.timeScale = 1f;
        TimeScript.enabled = true;
        for (int i = 0; i < Shot.Length; i++)
        {
            Shot[i].enabled = true;
        }
    }
    public void OnWindowEnabled()
    {
        MenuButton.SetActive(false);
        MenuWindow.SetActive(true);
        Time.timeScale = 0.0f;
        TimeScript.enabled = false;
        for (int i = 0; i < Shot.Length; i++)
        {
            Shot[i].enabled = false;
        }
    }
    public void OnRetry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetMusicEnabled(bool value) 
    {
        Audio.enabled = value;
    }
    public void SetVolume(float volume) 
    {
        AudioListener.volume = volume;
    }
    public void OnExit() 
    {
        Application.Quit(); 
    }
}
