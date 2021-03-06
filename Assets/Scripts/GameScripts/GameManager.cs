﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public float levelStartDelay = 2f;                      //Time to wait before starting level, in seconds.
	public static GameManager instance = null;
	[HideInInspector] public bool playersTurn = true;       //Boolean to check if it's players turn, hidden in inspector but public.

	private GameObject levelImage;                         
	private LevelManager levelManager;
	private bool doingSetup = false;
	[SerializeField]
	private Player player;



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

	public void StartBattle(List<GameObject> attackers, List<GameObject> protectors)
	{
		doingSetup = true;
	}
	private void Strike(int damageFirst, int defenceSecond, int accuracyFirst, int agilitySecond)
	{
		if ((accuracyFirst - agilitySecond / 2) - Random.Range(0, 100) > 0)
			return;
	}
	
}
