using UnityEngine;

public class gun : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public Camera fpsCam;

	void Start () {
		fpsCam = Camera.main;
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) 
		{
			Shoot();
		}

	}
	void Shoot() {
		RaycastHit hit;
		//
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
			Debug.Log(hit.transform.name);
			//Hey ben, got your drawRay working. It just needed a duration and the rays draw in the scene but not in the game
			Debug.DrawRay(GameObject.Find("Skorpion_VZ").transform.position, transform.TransformDirection(Vector3.forward)*hit.distance, Color.green, 10f);
		}

	}
}