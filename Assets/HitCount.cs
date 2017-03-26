using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCount : MonoBehaviour {

	public static int hitCount=0;
	public static bool gameOver = false;

	void Start(){
		hitCount = 0;
		gameOver = false;
	}

	public static void addHit(){
		hitCount++;
		Debug.Log (hitCount.ToString() + " HEALTH GONE");
	}

	public static int getHits(){
		return hitCount;
	}
}
