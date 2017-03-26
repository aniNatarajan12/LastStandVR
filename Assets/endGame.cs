using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour {

	[SerializeField] GameObject disableStuff;
	[SerializeField] GameObject enableStuff;

	void Update () {
		if (HitCount.getHits () >= 20) {
			HitCount.gameOver = true;
			disableStuff.SetActive (false);
			enableStuff.SetActive (true);
		}
	}

}
