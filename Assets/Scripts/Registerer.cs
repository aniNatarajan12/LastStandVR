using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registerer : MonoBehaviour {

	[SerializeField] Enemy enemy;

	void Start () {
		enemy = GetComponent<Enemy> ();
		EnemyManager.RegisterEnemy (Spawner.getNum(),enemy);
	}
}
