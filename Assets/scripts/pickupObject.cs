using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupObject : MonoBehaviour {

public Text pickupText;
public GameObject player;
public bool pickingUp = false;


public 
	// Use this for initialization
	void Start () {
		pickupText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider thing)
	{
		Debug.Log("triggered");
		if(thing.gameObject.tag == "item")
		{
			pickupText.text = "e";
		}
	}

	void OnTriggerStay(Collider thing)
	{

			if(Input.GetButtonDown("Pickup/Drop") && thing.gameObject.tag == "item")
			{
				if(player.GetComponent<inventory>().currItemID != 0 )
				{
					player.GetComponent<inventory>().DropItem();
				}

				player.GetComponent<inventory>().SetCurrItemID(thing.GetComponent<dropedItem>().itemID);
				Destroy(thing.gameObject);
				Destroy(thing.gameObject.transform.parent.gameObject);
				pickingUp = true;
				Invoke("SetPickingUpFalse", 0.25f);
			}
	}
	void OnTriggerExit(Collider thing)
	{
		Debug.Log("triggered");
		if(thing.gameObject.tag == "item")
		{
			pickupText.text = "";
		}
	}
		void SetPickingUpFalse()
	{
		pickingUp = false;
	}
}
