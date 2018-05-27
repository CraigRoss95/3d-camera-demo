using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour {

	// Use this for initialization
	public int currItemID = 0;
	public GameObject lantern;
	public GameObject lanternDrop;

	public GameObject ball;
	public GameObject ballDrop;
	public bool pickingUp = false;
	public GameObject pickupZone;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckItem();
		CheckDropItem();
		
	}
	void CheckDropItem()
	{
		if(Input.GetButtonDown("Use") && currItemID != 0 && pickupZone.GetComponent<pickupObject>().pickingUp == false)
		{
			DropItem();

		}
	}

	public void DropItem()
	{
		if(currItemID == 1)
			{
				Instantiate(lanternDrop, lantern.transform.position, lantern.transform.rotation);
			}
			else if(currItemID == 2)
			{
				Instantiate(ballDrop, ball.transform.position, ball.transform.rotation);
			}
			currItemID = 0;
	}
	void CheckItem()
	{
		if (currItemID == 1)
		{
			lantern.SetActive(true);
		}
		else
		{
			lantern.SetActive(false);
		}
			if (currItemID == 2)
		{
			ball.SetActive(true);
		}
		else
		{
			ball.SetActive(false);
		}
	}
	public void SetCurrItemID(int id)
	{
		currItemID = id;
	}
}
