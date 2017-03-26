using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using redisU.events;
using redisU.framework;
using redisU.exceptions;

public class RedisMouse : MonoBehaviour {

	private RedisConnection redis = null;

    void Start(){
		connect ();
    }

	void connect() {
		redis = new RedisConnection("10.10.180.94", 6379);
//		Debug.Log ("Connect");
	}

	void disconnect() {
	}

	public double getXRot() {
		double x = double.Parse(redis.Get<string, string> ("xRot"));
//		Debug.Log (x.ToString() + " X");
		return x;
	}

	public double getZRot() {
		double z = double.Parse(redis.Get<string, string> ("zRot"));
//		Debug.Log (z.ToString() + " Z");
		return z;
	}

	public bool getShouldFire() {
		string val = redis.Get<string, string> ("fire");
//		Debug.Log (val + "  FIRE");
		if (val.Equals ("1"))
			return true;
		else
			return false;
	}

	public void afterFired() {
		redis.Set<string, string> ("fire", "0");
	}
}