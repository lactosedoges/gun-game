using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float distToGround;
	public float walkSpeed;
	public float jumpSpeed;

	GameObject gunTip;
	LineRenderer bulletLine;
	Rigidbody rb;
	Vector3 moveDirection;
	CapsuleCollider col;
	RaycastHit objectHit;
	Camera cam;


	void Jump()
	{
		rb.velocity += new Vector3 (0, jumpSpeed * Time.deltaTime, 0);	
	}

	public bool IsGrounded(Vector3 dir)
	{
		float distanceToPoints = col.height / 2 - col.radius;

		//finds point1 and point2
		Vector3 point1 = transform.position + col.center + Vector3.up * distanceToPoints;
		Vector3 point2 = transform.position + col.center - Vector3.up * distanceToPoints;

		float radius = col.radius * 1f;
		float castDistance = 0.1f;

		RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, dir, castDistance);	

		foreach (RaycastHit objectHit in hits)
		{	
			if(objectHit.transform.tag == "ground")
			{
				return true;
			}
		}
		return false;
	}

	void Awake()
	{
		bulletLine = GetComponent<LineRenderer>();
		rb = GetComponent<Rigidbody>();
		col = GetComponent<CapsuleCollider>();
	}

	// Use this for initialization
	void Start () {
		distToGround = col.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Shoot();
		float horizontalMovement = 0;
		float verticalMovement = 0;

		if (CanMove(transform.right * Input.GetAxisRaw("Horizontal")))
		{
			horizontalMovement = Input.GetAxisRaw("Horizontal");
		}

		if (CanMove(transform.forward * Input.GetAxisRaw("Vertical")))
		{
			verticalMovement = Input.GetAxisRaw("Vertical");
		}

		//to help you move slanted
		moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
	}
		void FixedUpdate()
		{
			Move();

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded(Vector3.down)){
			Jump();
		}
		}

//	void Shoot() {
//		bulletLine.enabled = false;
//		if (Input.GetButtonDown ("Fire1")) {
//			bulletLine.enabled = true;
//			bulletLine.SetPosition(bulletLine.materials[0].GetInt(0), gunTip); 
//			Vector3 origin = cam.transform.position;
//			Vector3 direction = cam.transform.forward;
//			float distance = 1000f;
//			RaycastHit hit;
//		
//			if (Physics.Raycast(origin, direction, out hit, distance)) {
//				bulletLine.SetPosition(bulletLine.materials[1].GetInt(0), hit.point); 
//			} else {
//				
//			}
//		
//		}
//	}
		void Move()
		{	
			Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
			//the velocity is the moveDirection times the walkSpeed times the Time.deltaTime,which is
			//used to smooth things out
			rb.velocity = moveDirection * walkSpeed * Time.deltaTime;
			rb.velocity += yVelFix;
		}

		bool CanMove(Vector3 dir)
		{
			float distanceToPoints = col.height / 2 - col.radius;

			//finds point1 and point2
			Vector3 point1 = transform.position + col.center + Vector3.up * distanceToPoints;
			Vector3 point2 = transform.position + col.center - Vector3.up * distanceToPoints;

			//makes it slightly smaller so doesn't think ground is wall
			float radius = col.radius * 0.95f;
			float castDistance = 0.5f;

			RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, dir, castDistance);	

			foreach (RaycastHit objectHit in hits)
			{	
				//LABEL THEM WALL!!!!!!
				if(objectHit.transform.tag == "Wall")
				{
					return false;
				}
			}

			return true;
		}
	}