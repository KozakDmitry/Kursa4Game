using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
	public GameObject gameManager;
	//public GameObject soundManager;        
	public Button button;

	void Awake()
	{
	
		if (GameManager.instance == null)
			Instantiate(gameManager);

		
		//if (SoundManager.instance == null)

		//	//Instantiate SoundManager prefab
		//	Instantiate(soundManager);
	}

	void Start()
	{

	}


	public void StartGameButton()
	{
		SceneManager.LoadScene("Test");
	}


	public void OptionsButton()
	{


	}


	public void ExitGameButton()
	{
		Application.Quit();
	}
}
