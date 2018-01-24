using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {
	public bool PlayerWon;
	public bool PlayerLost;

	public GameObject WinUI;
	public GameObject LoseUI;
	public GameObject enemy;
	public GameObject player;

	public int currentHealth;

	public GameObject eventSystem;
	public int currLevel;
	public string[] levelNames = new string[2] { "level1", "level2"};

	GameLogic gameLogic;
	PlayerHealth playerHealth;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		currLevel = SceneManager.GetActiveScene().buildIndex;
	}
	
	void Update () 
	{
		currentHealth = playerHealth.currentHealth;
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		
		if(enemy == null)
		{
			PlayerWin();
		}

		if(currentHealth <= 0)
		{
			PlayerLose();
		}	
	}


	public void PlayerWin()
	{
		PlayerWon = true;
		WinUI.SetActive(true);
		
		//Load Next Level
		SteamVR_LoadLevel.Begin("level2");	
	}

	public void PlayerLose()
	{
		PlayerLost = true;
		LoseUI.SetActive(true);

		//Load Same Level
		SteamVR_LoadLevel.Begin("level1");	
	}
}
