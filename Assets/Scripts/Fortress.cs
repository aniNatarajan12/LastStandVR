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
		}
	}

	public void takeDmg(int _dmg){
		health -= _dmg;
	}
}
