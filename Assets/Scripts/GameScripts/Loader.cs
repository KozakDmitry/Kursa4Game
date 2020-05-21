using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Loader : MonoBehaviour
{
	public bool isFullScreen;
	public AudioMixer am;
	public GameObject gameManager;
	public Slider slider;
	//public GameObject soundManager;        
	public Button button;

	Resolution[] rsl;
	List<string> resolutions;
	public Dropdown dropdown;

	public void AudioVolume()
	{
		am.SetFloat("masterVolume", slider.value);
	}
	public void Resolution(int r)
	{
		Screen.SetResolution(rsl[r].width, rsl[r].height, isFullScreen);
	}

	void Awake()
	{
	
		if (GameManager.instance == null)
			Instantiate(gameManager);


		//if (SoundManager.instance == null)

		//	//Instantiate SoundManager prefab
		//	Instantiate(soundManager);
	}
	public void FullScreenToggle()
	{
		isFullScreen = !isFullScreen;
		Screen.fullScreen = isFullScreen;
	}
	void Start()
	{
		AudioVolume();
	}


	public void StartGameButton()
	{
		SceneManager.LoadScene("City");
	}


	public void OptionsButton()
	{


	}


	public void ExitGameButton()
	{
		Application.Quit();
	}
}
