using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour {

	[SerializeField] public int score = 0;
	[SerializeField] public PlayerUI playerUI;

	public void gotAKill(){
		score++;
		playerUI.changeScore (score);
	}
}
