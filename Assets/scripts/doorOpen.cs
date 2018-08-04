//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class doorOpen : MonoBehaviour {
//
//	float startTime;
//	bool isOpened = false;
//	Rigidbody rb;
//	CapsuleCollider col;
//	Camera cam;
//
//	void Awake(){
//		rb = GetComponent<Rigidbody>();
//		col = GetComponent<CapsuleCollider>(); 
//		//Debug.Log("Awake works");
//
//		cam = Camera.main; 
//	}
//
//	void CheckInteraction() {
//		
//		Vector3 origin = cam.transform.position;
//		Vector3 direction = cam.transform.forward;
//		float distance = 4f;
//
//		RaycastHit hit;
//		//Debug.Log("CheckInteraction works");
//
//		if (Physics.Raycast (origin, direction, out hit, distance)) {
//		
//			if (hit.transform.tag == "Door") {
//			
//				if (Input.GetKeyDown(KeyCode.E))
//					hit.transform.gameObject.GetComponent<doorOpen>().enabled = true;
//				Debug.Log("E works");
//			}
//		}
//
//
//	}
//
////	void OnEnable () {
////		isOpened = !isOpened;
////		startTime = Time.time;
//		//Debug.Log ("OnEnable works");
////	}
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//		CheckInteraction();
//		//Debug.Log("Update works");
//		if (isOpened) {
//			transform.Rotate (transform.up, -90 * Time.deltaTime);
//			Debug.Log("isOpened works");
//		} else {
//			transform.Rotate (transform.up, 90 * Time.deltaTime);
//			Debug.Log("Opposite works");
//		}
//
//
//		if (Time.time - startTime > 1f) {
//			enabled = false;
//		}
//	}
//}


using UnityEngine;
using System.Collections;

public class doorOpen : MonoBehaviour{
	float startTime;
	bool isOpened = false;

	void OnEnable(){
		isOpened = !isOpened;

		startTime = Time.time;
	}

	void Update () {
				
				//CheckInteraction();
				//Debug.Log("Update works");
				if (isOpened) {
					transform.Rotate (transform.up, -90 * Time.deltaTime);
					//Debug.Log("isOpened works");
				} else {
					transform.Rotate (transform.up, 90 * Time.deltaTime);
					//Debug.Log("Opposite works");
				}
		
		
				if (Time.time - startTime > 1f) {
					enabled = false;
				}
			}
		}