using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {

	[SerializeField] private RectTransform healthFill;
	[SerializeField] private Text scoreText;
	// Update is called once per frame
	void Update () {
		healthFill.localScale = new Vector3(1f, 1f-HitCount.hitCount/30f, 1f);
		scoreText.text = "SCORE: " + HitCount.kills.ToString();
	}
}
