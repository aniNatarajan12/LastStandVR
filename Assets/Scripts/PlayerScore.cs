using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	int lastKills = 0;

	public int high = 0;

	void Start () {
		StartCoroutine(SyncScoreLoop());
	}

	void OnDestroy () {
		SyncNow();
	}

	IEnumerator SyncScoreLoop () {
		while (true) {
			yield return new WaitForSeconds(2f);

			SyncNow();
		}
	}

	void SyncNow () {
		if (UserAccountManager.IsLoggedIn) {
			UserAccountManager.instance.GetData(OnDataRecieved);
		}
	}

	void OnDataRecieved(string data) {
		if (HitCount.kills <= lastKills)
			return;

		high = DataTranslator.DataToKills(data);

		if (HitCount.kills > high) {
			high = HitCount.kills;
			Debug.Log ("NEW HIGH");
		}

		string newData = DataTranslator.ValuesToData(high);

		Debug.Log("Syncing: " + newData);

		lastKills = HitCount.kills;

		UserAccountManager.instance.SendData(newData);
	}

}
