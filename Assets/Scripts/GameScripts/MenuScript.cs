using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static bool gamePaused = false;
    public AudioMixer am;
    public Slider slider;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        AudioVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        if (gamePaused)
        {
            Resume();
        }
        else
            Pause();
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void AudioVolume()
    {
        am.SetFloat("masterVolume", slider.value);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
}
