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
	[SerializeField] private Animator anim;
	[SerializeField] private bool isLocal = true;
	[SerializeField] private int maxAmmo;
	[SerializeField] private int ammo;
	[SerializeField] private int dmg;
	[SerializeField] private float fireRate;
	[SerializeField] private float reloadTime;
	[SerializeField] private bool isReloading = false;

	[Header ("UI")]
	[SerializeField] private Text ammoText;
	[SerializeField] private Text scoreText;
	[SerializeField] private Image crosshair;

	[Header ("Redis")]
	RedisMouse rm;
	float getTime = 0.2f;
	float lastTime = 0f; 
	bool fire = false;

	void Start(){
		ammo = maxAmmo;
		rm = GetComponent<RedisMouse> ();
	}

	void Update(){
		if (!HitCount.gameOver && StartGame.gameStarted) {
			ammoText.text = ammo.ToString ();
			if (ammo <= 0) {
				Reload ();
				return;
			}

			checkCrosshairStatus ();

			if (!isLocal) {
				if (Time.time > lastTime) {
					fire = rm.getShouldFire ();
//			Debug.Log (fire.ToString() + "  SHOOOT");
					lastTime = Time.time + getTime;
				}

				if (fire) {
					Shoot ();
					rm.afterFired ();
					fire = false;
				}
			} else {
				if (Input.GetButtonDown("Fire1")) {
					Shoot ();
				}
			}
		}
	}

	void checkCrosshairStatus(){
		crosshair.color = Color.white;
		RaycastHit _hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, 150)) {
			if (_hit.collider.tag != "Environment") {
				crosshair.color = Color.red;
			}
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

		anim.SetBool("reloading", false);

		isReloading = false;
	}

	void onReload(){
		anim.SetBool("reloading", true);
	}

	void Shoot () {
		if (isReloading) {
			return;
		}

		if (ammo <= 0) {
			return;
		}

		ammo--;

		onShoot();

		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, 150) ) {
			if (_hit.collider.tag == "Enemy") {
				Enemy _enemy = EnemyManager.GetEnemy (_hit.transform.name);
				_enemy.takeDamage (dmg);
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
