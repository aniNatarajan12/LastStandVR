using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class endGame : MonoBehaviour {

	[SerializeField] GameObject disableStuff;
	[SerializeField] GameObject enableStuff;

	[SerializeField] PlayerScore ps;
	[SerializeField] Text scoreText;
	[SerializeField] Text highScoreText;
	[SerializeField] GameObject newHighScoreText;

	void Update(){
		if (HitCount.hitCount >= HitCount.maxHits) {
			gameOver ();
			scoreText.text = "SCORE: " + HitCount.kills.ToString ();
			HitCount.reset ();
		}
	}

	void gameOver(){
		if (HitCount.hitCount >= HitCount.maxHits) {
			HitCount.gameOver = true;
			disableStuff.SetActive (false);
			enableStuff.SetActive (true);

			int highScore = ps.high;
			highScoreText.text = "HIGHSCORE: " + highScore.ToString ();
			if (highScore < HitCount.kills) {
				newHighScoreText.SetActive (true);
			}
			Cursor.lockState = CursorLockMode.None;
		}
	}

}
