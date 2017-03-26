using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

	[SerializeField] GameObject disableStuff;
	[SerializeField] GameObject enableStuff;

	void Update () {
		if (HitCount.hitCount >= HitCount.maxHits) {
			HitCount.gameOver = true;
			disableStuff.SetActive (false);
			enableStuff.SetActive (true);
		}
	}

}
