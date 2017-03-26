using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	[SerializeField] private int health;
	[SerializeField] public int damage;
	public bool isDead = false;

	public int id;
	public Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
		Debug.Log (transform.name + " THIS IS THE NAME");
		transform.name = EnemyManager.ENEMY_ID_PREFIX + Spawner.getNum();
		id = int.Parse(Spawner.getNum ());
		Debug.Log (transform.name + " THIS IS THE NAME NAAAAAAAME");
	}

	public void takeDamage (int _amount)
	{
		Debug.Log(transform.name + " now has " + health + " health.!!!!");
		if (health <= 0) {
			return;
		}

		health -= _amount;

		Debug.Log(transform.name + " now has " + health + " health. REAL");

		if (health <= 0)
		{
			Die();
			isDead = true;
		}
	}

	private void Die()
	{
		//Disable the collider
		Collider _col = GetComponent<Collider>();
		if (_col != null)
			_col.enabled = false;

		//Spawn a death effect
		animator.SetBool("isDead", true);
		HitCount.addKill ();
		EnemyManager.UnRegisterEnemy (transform.name, id);
		Destroy (this, 3f);

		Debug.Log(transform.name + " is DEAD!");
	}

}
