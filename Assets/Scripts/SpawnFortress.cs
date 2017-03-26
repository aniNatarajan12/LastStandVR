using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFortress : MonoBehaviour {

	[SerializeField] private GameObject fortress;
	[SerializeField] private GameObject refer;

	void Start () {
		RaycastHit _hit;
		if (Physics.Raycast (refer.transform.position, -refer.transform.up, out _hit, 200)){
			Instantiate (fortress, new Vector3 (256.01f, 1.02f, 234.56f), Quaternion.LookRotation (_hit.normal));
		}
	}
}
