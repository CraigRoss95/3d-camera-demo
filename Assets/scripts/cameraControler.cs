using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour {
public Transform lookAt;
public Transform camTransfrom;
public float camSpeed;
public float maxCamAngle;
public float minCamAngle;
public float angleSpeed;
public LayerMask playerMask;
public float zoomSpeed;
private float mouseX = 0.0f;
private float mouseY = 0.0f;
public bool inverse;


private float tempDistance;
private float distance = 10.0f;
private float sensitivityX = 4.0f;
private float sensitivityY = 1.0f;
private float maxZoom = 10.0f;
private float userZoom;
private float toWall;
private RaycastHit angleHit;

	// Use this for initialization
	void Start () {
		camTransfrom = transform;
		distance = maxZoom;
		userZoom = maxZoom;
		toWall = 11.0f;


	}
	
	void LateUpdate()
	{
		Zoom();
	GetInput();

	if( toWall >= userZoom)
	{
		userZoom = userZoom - (Input.GetAxis("Mouse ScrollWheel")) * 4;
		
				distance = Mathf.Lerp(distance,userZoom, zoomSpeed * Time.deltaTime);
		userZoom = Mathf.Clamp(userZoom, 2.0f, 12.0f);
	}
	//zooming in while the camera is agenst a wall
	else if(toWall < userZoom && Input.GetAxis("Mouse ScrollWheel") > 0)
	{
		//Debug.Log("your good!");
		userZoom = toWall;
	}


	//Debug.Log("userzoom = " + userZoom);
		if(distance < 1)
		{
			distance = 1;
		}
		Vector3 dir = new Vector3 (0, 0, -distance);
		Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

		camTransfrom.position = Vector3.MoveTowards(camTransfrom.position, lookAt.position + rotation*dir, 1 );

		transform.LookAt(lookAt);
		lookAt.transform.LookAt(transform);
	}
	void GetInput()
	{	
		
		mouseX = mouseX + Input.GetAxis("Mouse X") * sensitivityX;
		
		if (Physics.Raycast(lookAt.transform.position, camTransfrom.position- lookAt.transform.position, out angleHit, distance + 2,playerMask))
		{
			
			if ((Vector3.Angle(angleHit.normal,Vector3.down) > 110))
			{
				mouseY = mouseY + 1;
			}
			else
			{
				if(inverse ==  true)
				{
					mouseY = mouseY - Input.GetAxis("Mouse Y") * sensitivityY;
				}
				else
				{
					mouseY = mouseY + Input.GetAxis("Mouse Y") * sensitivityY;
				}
				
			}
		}
		else
		{
			if(inverse == true)
			{
				mouseY = mouseY - Input.GetAxis("Mouse Y") * sensitivityY;
			}
			else{
				mouseY = mouseY + Input.GetAxis("Mouse Y") * sensitivityY;
			}
			
		}		
			mouseY = Mathf.Clamp (mouseY, minCamAngle, maxCamAngle);
		
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
						distance = Mathf.Lerp(distance,userZoom, zoomSpeed * Time.deltaTime);
			}
		}
		else 
		{
			toWall = Mathf.Infinity;
		}
		//Debug.Log("distance offset " + distanceOffset);
		
			
	}
}

