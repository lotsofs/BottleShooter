using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float xSensitivity = 1f;
	public float ySensitivity = 1f;
	public bool xFlip = false;
	public bool yFlip = false;

	private float yaw = 0f;
	private float pitch = 0f;

	// Start is called before the first frame update
	void Start()
	{
		// We need to set these so that we don't spawn with default orientation.
		pitch = transform.eulerAngles.x;
		yaw = -transform.eulerAngles.y;
	}

	// Update is called once per frame
	void Update()
	{
		float horizontal = Input.GetAxis("Mouse X") * xSensitivity * (xFlip ? 1 : -1);
		float vertical = Input.GetAxis("Mouse Y") * ySensitivity * (yFlip ? 1 : -1);

		yaw += horizontal;
		pitch += vertical;

		pitch = Mathf.Clamp(pitch, -90, 90);

		transform.eulerAngles = new Vector3(pitch, -yaw, 0f);
	}
}
