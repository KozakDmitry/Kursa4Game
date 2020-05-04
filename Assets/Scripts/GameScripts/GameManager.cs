using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
	public static GameManager instance = null;
	[HideInInspector] public bool playersTurn = true;       //Boolean to check if it's players turn, hidden in inspector but public.

	private GameObject levelImage;                         
	private LevelManager levelManager;
	private bool doingSetup = true;



	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);
		levelManager = GetComponent<LevelManager>();
		InitGame();
	}
	void InitGame()
	{
		doingSetup = true;
		levelImage = GameObject.Find("LevelImage");
	}

	
}
