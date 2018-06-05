using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkLock : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider thing)
	{
		
		if(thing.gameObject.tag == "door" && Input.GetButtonDown("Use"))
		{
		
			
			thing.gameObject.GetComponent<door>().Unlock((player.GetComponent<inventory>().GetItemID()));	
			
			if(thing.gameObject.GetComponent<door>().GetDestroyedKey())
			{
				player.GetComponent<inventory>().SetCurrItemID(0);
			}
		}
		if (thing.gameObject.tag == "swapper" && Input.GetButtonDown("Use"))
		{
			player.GetComponent<inventory>().SetCurrItemID(thing.gameObject.GetComponent<itemSwapper>().Swap(player.GetComponent<inventory>().GetItemID()));
		}
		if (thing.gameObject.tag == "toggler" && Input.GetButtonDown("Use"))
		{
			thing.gameObject.GetComponent<toggle>().Toggle();
		}
	}
}
