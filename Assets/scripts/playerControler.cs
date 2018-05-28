using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour {
	public Transform cam;
	public float velocity;
	public float turningSpeed;
	public LayerMask ground;

	private bool grounded;
	private float height = 1.0f;
	private float heightBuffer = 0.1f;
	public float maxAngle = 160.0f;
	public GameObject playerBody;
	private RaycastHit infront;
	private bool wallFound;




	private Vector2 input;

	private float angle;
	private float groundAngle;
	private Quaternion targetRotation;

	private Vector3 forward;
	private Vector3 forwardLeft;
	private Vector3 forwardRight;
	private RaycastHit hitInfo;
	private Transform sphereCastHit;
	

	void Start()
	{
	
	}

	void Update()
	{	

		GetInput();
		CalculateDirection();
		CalculateForward();
		CalculateGroundAngle();
		CheckGround();
		CastCircle();
		ApplyGravity();
		Lines();

		if(Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1)return;

		Rotate();
		Move();


	}

	void GetInput()
	{
		input.x = Input.GetAxisRaw("Horizontal");
		input.y = Input.GetAxisRaw("Vertical");
	}

	void CalculateDirection()
	{
		angle = Mathf.Atan2(input.x, input.y);
		angle = Mathf.Rad2Deg * angle;
		angle = angle + cam.eulerAngles.y;

	}

	void Rotate()
	{
		targetRotation = Quaternion.Euler(0,angle,0);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turningSpeed* Time.deltaTime);


		playerBody.transform.eulerAngles = new Vector3 ( - Vector3.Angle(hitInfo.normal, transform.forward) +90,angle, 0.0f);


		//playerBody.transform.rotation = Quaternion.AngleAxis (  transform.rotation.y, Vector3.up);
	

	}

	void Move()
	{if(groundAngle >= maxAngle) return;
		if(wallFound == false)
		{
		transform.position = transform.position +(forward * velocity * Time.deltaTime);
		}
	}

	void CalculateForward()
	{
		if(!grounded)
		{
			forward = transform.forward;
			return;
		}

		forward = Vector3.Cross(hitInfo.normal, -transform.right);
		forwardLeft =  Vector3.Cross(hitInfo.normal, transform.forward - transform.right);
		forwardRight =  Vector3.Cross(hitInfo.normal, -transform.forward -transform.right);
		

	}
	void CalculateGroundAngle()
	{
		if(!grounded)
		{
			groundAngle = 90;
			return;
		}
		groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
		if (groundAngle < Vector3.Angle(hitInfo.normal,transform.forward + transform.right))
		{
			groundAngle = Vector3.Angle(hitInfo.normal, transform.forward + transform.right);
		}
		if (groundAngle < Vector3.Angle(hitInfo.normal, transform.forward - transform.right))
		{
			groundAngle = Vector3.Angle(hitInfo.normal, transform.forward - transform.right);
		}
		if (groundAngle < Vector3.Angle(hitInfo.normal, transform.right))
		{
			groundAngle = Vector3.Angle(hitInfo.normal, transform.right);
		}
		if (groundAngle < Vector3.Angle(hitInfo.normal, -transform.right))
		{
			groundAngle = Vector3.Angle(hitInfo.normal, -transform.right);
		}
	}
	void CheckGround()
	{
		if(Physics.Raycast(transform.position, -Vector3.up, out hitInfo, height + heightBuffer, ground))
		{
			if(Vector3.Distance(transform.position,hitInfo.point) < height)
			{
				transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * height , 5 * Time.deltaTime);
			}
			grounded = true;
		}
		else
		{
			grounded = false;
		}


	}
	
	void ApplyGravity()
	{
		if(!grounded)
		{
			transform.position = transform.position + Physics.gravity * Time.deltaTime;
		}
	}
	
	void CastCircle()
	{

	}

	void Lines()
	{
		Debug.DrawLine(transform.position,transform.position+ forward *height * 2, Color.blue);
		Debug.DrawLine(transform.position,transform.position +  forwardLeft *height * 2, Color.red);
		Debug.DrawLine(transform.position,transform.position +  forwardRight *height * 2, Color.red);
		//Debug.DrawLine(transform.position, transform.position - Vector3.up * height, Color.green);
		if(Physics.Raycast(transform.position, forward, out infront, 0.6f ,ground))
		{
			wallFound = true;
			//Debug.Log("infront = " + infront.normal);
		}
		else if(Physics.Raycast(transform.position, forwardLeft, out infront, 0.6f ,ground))
		{
			wallFound = true;
		}
		else if(Physics.Raycast(transform.position, forwardRight, out infront, 0.6f ,ground))
		{
			wallFound = true;
		}

		else if(Physics.Raycast(transform.position+ new Vector3(0,height - heightBuffer, 0), forward, out infront, 0.5f ,ground))
		{
			wallFound = true;


		}
		else if(Physics.Raycast(transform.position + new Vector3(0,height + heightBuffer, 0), forwardLeft, out infront, 0.5f ,ground))
		{
			wallFound = true;
		}
		else if(Physics.Raycast(transform.position+ new Vector3(0,height - heightBuffer, 0), forwardRight, out infront, 0.5f ,ground))
		{
			wallFound = true;
		}

		else if(Physics.Raycast(transform.position+ new Vector3(0,-height - heightBuffer, 0), forward + new Vector3(0.0f,30.0f,0.0f), out infront, 0.3f ,ground))
		{
			wallFound = true;

			Debug.DrawLine( transform.position+ new Vector3(0,-height - heightBuffer, 0),infront.point, Color.red);
		}
		else if(Physics.Raycast(transform.position + new Vector3(0,-height - heightBuffer, 0), forwardLeft+ new Vector3(0.0f,30.0f,0.0f), out infront, 0.3f ,ground))
		{
			wallFound = true;
		}
		else if(Physics.Raycast(transform.position+ new Vector3(0,-height - heightBuffer, 0), forwardRight+ new Vector3(0.0f,30.0f,0.0f), out infront, 0.3f ,ground))
		{
			wallFound = true;
		}
		else
		{
		wallFound = false;
		}
	}



}
