using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class userLobby : MonoBehaviour {

	public Text usernameStartText;
	public Text usernameOverText;
	public GameObject score;
	public GameObject startStuff;
	public GameObject gameStuff;
	public GameObject gameOverStuff;
	public Text highScore;
	[SerializeField] private PlayerScore ps;
	[SerializeField] private Shooter shooter;

	void Start () {
		highScore.text = "HIGH SCORE: ...";
		if (UserAccountManager.IsLoggedIn) {
			usernameStartText.text = UserAccountManager.LoggedIn_Username;
			usernameOverText.text = UserAccountManager.LoggedIn_Username;
		}
		setHigh ();
	}

	void setHigh () {
		Debug.Log("GET DATA 1");
		if (UserAccountManager.IsLoggedIn) {
			Debug.Log("GET DATA 22");
			UserAccountManager.instance.GetData(OnDataRecieved);
		}
	}

	void OnDataRecieved(string data) {
		Debug.Log("GOT DATA");
		highScore.text = "HIGH SCORE: " + DataTranslator.DataToKills(data);
	}

	public void LogOut() {
		HitCount.gameOver = false;
		StartGame.gameStarted = false;

		if (UserAccountManager.IsLoggedIn)
			UserAccountManager.instance.LogOut();
	}

	public void startGame(){
		StartGame.gameStarted = true;
		startStuff.SetActive (false);
		gameStuff.SetActive (true);
		score.SetActive (true);
	}

	public void reStartGame(){
		Enemy[] enemies = EnemyManager.getEnemyArray ();

		for (int i = 0; i < enemies.Length; i++) {
			enemies [i].takeDamage (7122002);
		}

		HitCount.reset ();
		shooter.Reload ();

		gameOverStuff.SetActive (false);
		startStuff.SetActive (true);
		score.SetActive (false);
		
		HitCount.gameOver = false;
		StartGame.gameStarted = false;
	}

}
