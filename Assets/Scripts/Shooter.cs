using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour {

	[Header ("PREFABS")]
	[SerializeField] private Camera cam;
	[SerializeField] private ParticleSystem muzzleFlash;
	[SerializeField] private GameObject hitEffectPrefab;

	[Header ("WEAPON")]
	[SerializeField] private int maxAmmo;
	[SerializeField] private int ammo;
	[SerializeField] private int dmg;
	[SerializeField] private float fireRate;
	[SerializeField] private float reloadTime;
	[SerializeField] private bool isReloading = false;

	[Header ("UI")]
	[SerializeField] private Text ammoText;
	[SerializeField] private Text scoreText;
	[SerializeField] private int kills;

	[Header ("Redis")]
	RedisMouse rm;
	float getTime = 0.5f;
	float lastTime = 0f; 
	bool fire = false;

	void Start(){
		ammo = maxAmmo;
		rm = GetComponent<RedisMouse> ();
	}

	void Update(){
		ammoText.text = ammo.ToString ();
		if (ammo <= 0)
		{
			Reload ();
			return;
		}

		if (Time.time > lastTime) {
			fire = rm.getShouldFire();
			Debug.Log (fire.ToString() + "  SHOOOT");
			lastTime = Time.time + getTime;
		}

		if (fire) {
			Shoot();
			rm.afterFired ();
			fire = false;
		}
	}

	public void Reload ()
	{
		if (isReloading)
			return;

		StartCoroutine(Reload_Coroutine());
	}

	private IEnumerator Reload_Coroutine ()
	{
		Debug.Log("Reloading...");

		isReloading = true;

		onReload();

		yield return new WaitForSeconds(reloadTime);

		ammo = maxAmmo;

		Animator anim = GetComponent<Animator>();
		anim.SetBool("reloading", false);

		isReloading = false;
	}

	void onReload(){
		Animator anim = GetComponent<Animator>();
		anim.SetBool("reloading", true);
	}

	void Shoot ()
	{
		if (isReloading)
		{
			return;
		}

		if (ammo <= 0)
		{
			return;
		}

		ammo--;

		onShoot();

		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 150) )
		{
			if (_hit.collider.tag == "Enemy") {
				Debug.Log (_hit.transform.name + " HIT");
				Enemy _enemy = EnemyManager.GetEnemy (_hit.transform.name);
				Debug.Log (_enemy.transform.name + " HITTTT");
				_enemy.takeDamage (dmg);
				if (_enemy.isDead) {
					kills++;
					Debug.Log ("GOT A KILL");
					scoreText.text = "SCORE: " + kills.ToString ();
				}
			}
			onHit(_hit.point, _hit.normal);
		}
	}

	void onShoot(){
		muzzleFlash.Play();
	}

	void onHit(Vector3 _pos, Vector3 _normal){
		GameObject _hitEffect = (GameObject)Instantiate(hitEffectPrefab, _pos, Quaternion.LookRotation(_normal));
		Destroy(_hitEffect, 2f);
	}
}
