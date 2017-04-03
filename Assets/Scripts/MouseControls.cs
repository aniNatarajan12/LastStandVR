using UnityEngine;

[RequireComponent (typeof(PlayerMotor))]
public class MouseControls : MonoBehaviour {

	[SerializeField]
	private float lookSensitivity = 3f;

	// Component caching
	private PlayerMotor motor;

	void Start () {
		motor = GetComponent<PlayerMotor> ();
	}

	void Update () {

		if (HitCount.gameOver || !StartGame.gameStarted) {
			motor.Rotate (Vector3.zero);
			motor.RotateCamera (0f);
			return;
		}

		if (Cursor.lockState != CursorLockMode.Locked)
			Cursor.lockState = CursorLockMode.Locked;

		//Calculate rotation as a 3D vector (turning around)
		float _yRot = Input.GetAxisRaw ("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//Apply rotation
		motor.Rotate (_rotation);

		//Calculate camera rotation as a 3D vector (turning around)
		float _xRot = Input.GetAxisRaw ("Mouse Y");

		float _cameraRotationX = _xRot * lookSensitivity;

		//Apply camera rotation
		motor.RotateCamera (_cameraRotationX);

	}

}
