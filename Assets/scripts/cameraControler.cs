using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour {
public Transform lookAt;
public Transform camTransfrom;
public float camSpeed;
public float maxCamAngle;
public float minCamAngle;
public LayerMask playerMask;
private float mouseX = 0.0f;
private float mouseY = 0.0f;


private float tempDistance;
private float distance = 10.0f;
private float sensitivityX = 4.0f;
private float sensitivityY = 1.0f;
private float maxZoom = 10.0f;
private float userZoom;
private float toWall;

	// Use this for initialization
	void Start () {
		camTransfrom = transform;
		distance = maxZoom;
		userZoom = maxZoom;
		toWall = 11.0f;


	}
	
	// Update is called once per frame
	void Update () {
		

	
	}
	void LateUpdate()
	{
	GetInput();

	CalcAutoAngle();
	if( toWall >= userZoom)
	{
		userZoom = userZoom - (Input.GetAxis("Mouse ScrollWheel"));
		
		distance = userZoom;
		userZoom = Mathf.Clamp(userZoom, 1.0f, 10.0f);
	}
	//zooming in while the camera is agenst a wall
	else if(toWall < userZoom && Input.GetAxis("Mouse ScrollWheel") > 0)
	{
		//Debug.Log("your good!");
		userZoom = toWall;
	}


	//Debug.Log("userzoom = " + userZoom);
		Zoom();
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

		camTransfrom.position = Vector3.MoveTowards(camTransfrom.position, lookAt.position + rotation*dir, camSpeed * Time.deltaTime );

		transform.LookAt(lookAt);
		lookAt.transform.LookAt(transform);
	}
	void GetInput()
	{
		mouseX = mouseX + Input.GetAxis("Mouse X") * sensitivityX;
		mouseY = mouseY + Input.GetAxis("Mouse Y") * sensitivityY;
		mouseY = Mathf.Clamp (mouseY, minCamAngle, maxCamAngle);
	}
	void CalcAutoAngle()
	{
		RaycastHit cameraAngleHit;
		if(Physics.Raycast(lookAt.transform.position, new Vector3(camTransfrom.position.x -lookAt.position.x, 0, camTransfrom.position.z -lookAt.position.z), out cameraAngleHit, distance + 0.5f ,playerMask))
		{
			Debug.DrawLine(lookAt.transform.position, cameraAngleHit.point, Color.blue);
			if(Vector3.Angle(cameraAngleHit.normal,Vector3.down) > 110)
			{
				minCamAngle = 180 - Vector3.Angle(cameraAngleHit.normal,Vector3.down) ; 
				Debug.Log("down angle " +minCamAngle);
			}
		}
		else
		{
			minCamAngle = 0;
		}
	}
	private void Zoom()
	{
		RaycastHit hit;
		if(Physics.Raycast(lookAt.transform.position, lookAt.transform.TransformDirection(Vector3.forward), out hit, maxZoom, playerMask.value))
		{
			toWall = hit.distance;
			if(hit.distance < userZoom)
			{
				//Debug.Log(" hit distance: " + hit.distance);
				distance = hit.distance;
			}
			else 
			{
				distance = userZoom;
			}
		}
		else 
		{
			toWall = Mathf.Infinity;
		}
		//Debug.Log("distance offset " + distanceOffset);
		
			
	}
}

