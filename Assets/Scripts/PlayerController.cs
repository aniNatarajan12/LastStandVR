using UnityEngine;

[RequireComponent (typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float lookSensitivity = 3f;

	[SerializeField] float getTime = 0.5f;
	float lastTime = 0f;

	float _yRot = 0f;
	float _xRot = 0f;

	RedisMouse rm;

	// Component caching
	private PlayerMotor motor;

	void Start () {
		motor = GetComponent<PlayerMotor> ();
		rm = GetComponent<RedisMouse> ();
	}

	void Update () {
		if (HitCount.gameOver || !StartGame.gameStarted) {
			_yRot = 0;
			_xRot = 0;
			motor.Rotate (Vector3.zero);
			motor.RotateCamera (0f);
			return;
		}

		if (Cursor.lockState == CursorLockMode.None)
			Cursor.lockState = CursorLockMode.Locked;

		if (Time.time > lastTime) {
			_yRot = (float)rm.getXRot ();
			_xRot = (float)rm.getZRot ();
			lastTime = Time.time + getTime;
			

			Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

			//Apply rotation
			motor.Rotate (_rotation);

			float _cameraRotationX = _xRot * lookSensitivity;

			//Apply camera rotation
			motor.RotateCamera (_cameraRotationX);
		}
	}
}
