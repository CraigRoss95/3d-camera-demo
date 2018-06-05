using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour {
public bool on;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Toggle()
	{
		if(on == true)
		{
			on = false;
		}
		else if(on == false)
		{
			on = true;
		}
	}

	public bool GetOn()
	{
		return on;
	}
}
