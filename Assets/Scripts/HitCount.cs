using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCount : MonoBehaviour {

	public static int hitCount=0;
	public static float maxHits=5;
	public static bool gameOver = false;
	public static int kills=0;

	void Start(){
		hitCount = 0;
		gameOver = false;
	}

	public static void addHit(){
		hitCount++;

//		Debug.Log (hitCount.ToString() + " HEALTH GONE");
	}

	public static void addKill(){
		kills++;
		hitCount--;

		if (hitCount < 0) {
			hitCount = 0;
		}
	}

	public static int getHits(){
		return hitCount;
	}

	public static void reset(){
		hitCount = 0;
		kills = 0;
	}

}
