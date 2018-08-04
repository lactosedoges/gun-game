using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera cam;

	Vector3 offset;

	public float minimumX = -60f;
	public float maximumX = 60f;
	public float minimumY = -360f;
	public float maximumY = -360;

	public float sensitivityX = 2f;
	public float sensitivityY = 2f;

	float rotationY = 0f;
	float rotationX = 0f;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		
		rotationY += Input.GetAxis("Mouse X") * sensitivityY;
		rotationX += Input.GetAxis("Mouse Y") * sensitivityX;

		Camera.main.transform.position = transform.position + offset;


		rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

		transform.localEulerAngles = new Vector3(0, rotationY, 0);
		cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);

		if (Input.GetKey(KeyCode.Escape))
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	if (Input.GetKey(KeyCode.M))
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
}	
}
}
