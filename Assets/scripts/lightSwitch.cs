using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class lightSwitch : MonoBehaviour {

private bool isOn;
public GameObject light;

	// Use this for initialization
	void Start () 
	{
		isOn = gameObject.GetComponent<toggle>().GetOn();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( isOn != gameObject.GetComponent<toggle>().GetOn())
		{
			isOn = gameObject.GetComponent<toggle>().GetOn();
			light.gameObject.GetComponent<theSun>().Switch();
		}
	}
}
