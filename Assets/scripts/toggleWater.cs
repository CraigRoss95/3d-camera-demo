using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWater : MonoBehaviour {
	public GameObject lever;
	public GameObject objects;
	private bool showObject;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		showObject = lever.gameObject.GetComponent<toggle>().GetOn();
		ShowHide();
		
	}
	void ShowHide()
	{
		if(showObject == true)
		{
			objects.gameObject.SetActive(true);
		}
		else{
			objects.gameObject.SetActive(false);
		}
	}
}
