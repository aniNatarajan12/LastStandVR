using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyManager : MonoBehaviour {

	public const string ENEMY_ID_PREFIX = "Enemy ";

	private static Dictionary<string, Enemy> enemies = new Dictionary<string, Enemy>();

	public static void RegisterEnemy (string _num, Enemy _enemy)
	{
		string _enemyID = ENEMY_ID_PREFIX + _num;
		enemies.Add(_enemyID, _enemy);

		Debug.Log (_enemyID + " THIS IS THE ACTUAL ID");
		_enemy.transform.name = _enemyID;
		for (int i = 0; i < enemies.Count; i++) {
			Debug.Log ("i: " + i.ToString() + "   WHAT IT IS: " + enemies [ENEMY_ID_PREFIX + i.ToString()].transform.name);
		}
	}

	public static void UnRegisterEnemy (string _enemyID, int _id)
	{
		enemies.Remove(_enemyID);
		for (int i = _id; i < enemies.Count; i++) {
			enemies [ENEMY_ID_PREFIX + i.ToString ()].id -= 1;
			enemies [ENEMY_ID_PREFIX + i.ToString ()].transform.name = ENEMY_ID_PREFIX + enemies [ENEMY_ID_PREFIX + i.ToString ()].id;
			Debug.Log ("i: " + i.ToString() + "   WHAT IT IS: " + enemies [ENEMY_ID_PREFIX + i.ToString()].transform.name);
		}
	}

	public static Enemy GetEnemy (string _enemyID)
	{
		return enemies[_enemyID];
	}
}
