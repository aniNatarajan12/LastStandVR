using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	RectTransform healthFill;
	Text scoreText;

	[SerializeField] Fortress fortress;
	[SerializeField] int score;

	void update(){
		setHealth(fortress.healthPCT);
	}

	public void setHealth(float _amt){
		healthFill.localScale = new Vector3(1f, _amt, 1f);
	}

	public void changeScore(int _amt){
		scoreText.text = "SCORE: " + _amt.ToString();
	}
}
