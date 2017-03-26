using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	[SerializeField] private int hpLEFT = 20;
	[SerializeField] private int maxHP = 20;

	void start(){
		
	}

	void Update(){
		if (hpLEFT <= 0) {
			Debug.Log("GAME OVER!!!!!");
		}

	}

	public void takeDMG(){
		hpLEFT--;
	}

}
