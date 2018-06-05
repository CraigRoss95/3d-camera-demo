using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSwapper : MonoBehaviour {

	public int inItemID;
	public int outItemID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int Swap(int input)
	{
		if (input == inItemID)
		{
			return outItemID;
		}
		else
		{
		 return input;	
		}
	}
}
