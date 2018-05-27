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


private Camera cam;
private float tempDistance;
private float distance = 10.0f;
private float sensitivityX = 4.0f;
private float sensitivityY = 1.0f;
private float distanceOffset = 0.0f;
private float zoomSpeed = 0.1f;
private float maxZoom = 10.0f;
private bool canZoom;
private float userZoom;
private float toWall;

	// Use this for initialization
	void Start () {
		canZoom = true;
		camTransfrom = transform;
		cam = Camera.main;
		distance = maxZoom;
		userZoom = maxZoom;
		toWall = 11.0f;


	}
	
	// Update is called once per frame
	void Update () {
		

	
	}
	void LateUpdate()
	{
		//Debug.Log("can zoom = " + canZoom);
		mouseX = mouseX + Input.GetAxis("Mouse X") * sensitivityX;
		mouseY = mouseY + Input.GetAxis("Mouse Y") * sensitivityY;
		mouseY = Mathf.Clamp (mouseY, minCamAngle, maxCamAngle);
	//zooming in or out if the camera is not aggenst a wall
	if( toWall >= userZoom)
	{
		userZoom = userZoom - (Input.GetAxis("Mouse ScrollWheel"));
		userZoom = Mathf.Clamp(userZoom, 1.0f, 10.0f);
		distance = userZoom;
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
	private void Zoom()
	{
		RaycastHit hit;
		if(Physics.Raycast(lookAt.transform.position, lookAt.transform.TransformDirection(Vector3.forward), out hit, maxZoom, playerMask.value))
		{
			toWall = hit.distance;
			if(hit.distance < userZoom)
			{
				//Debug.Log(" hit distance: " + hit.distance);
				distance = distance - camSpeed;
				distance = hit.distance -1;
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

