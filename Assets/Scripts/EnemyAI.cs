using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

	[SerializeField] private float Distance;
	[SerializeField] private GameObject Target;
	[SerializeField] private int attackRange;
	[SerializeField] private float  moveSpeed;
	[SerializeField] private float attackRepeatTime;
	private Animator animator;
	private Enemy en;

	[SerializeField] public int damage;

	[SerializeField] private float attackTime;

	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		animator = GetComponent<Animator>();
		en = GetComponent<Enemy>();
		damage = en.damage;
	}
	
	// Update is called once per frame
	void Update () {
		if (!HitCount.gameOver && !en.isDead) {
			Distance = Vector3.Distance (Target.transform.position, transform.position);

			if (Distance > attackRange) {
				transform.LookAt (Target.transform.position);
				chase ();
				animator.SetFloat ("speed", 1);
			} else {
				attack ();
			}
		} else {
			animator.SetBool ("attack", false);
			animator.SetFloat ("speed", 0);
		}
	}

	void chase () {
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		if (Distance < attackRange) {
			attack ();
		}
	}

	public void isHit(){
		animator.SetBool ("isHit", true);
	}

	void attack () {
		if (Time.time > attackTime) {
			animator.SetBool ("attack", false);
			animator.SetBool ("attack", true);

			HitCount.addHit ();

			attackTime = Time.time + attackRepeatTime;
		}
	}

}