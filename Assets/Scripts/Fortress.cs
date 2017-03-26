using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fortress : MonoBehaviour {

	[SerializeField] private float maxHealth;
	[SerializeField] public int health;
	[SerializeField] public float healthPCT = 1;
	[SerializeField] public RectTransform healthBar;

	void start(){
		health = 100;
	}

	void Update(){
		if (health <= 0) {
//			Debug.Log("IM DEAD!");
		}
	}

	public void takeDmg(int _dmg){
		health -= _dmg;
		Debug.Log("AHHH I TOOK DMG I HAVE HEALTH LEFT: " + health.ToString());
	}
}
