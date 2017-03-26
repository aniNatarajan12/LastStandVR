using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour {

	[SerializeField] private RectTransform healthFill;
	
	// Update is called once per frame
	void Update () {
		healthFill.localScale = new Vector3(1f, 1 - (HitCount.getHits() / 20f), 1f);
	}
}
