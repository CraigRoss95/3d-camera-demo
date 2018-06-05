using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
public int lockID;
public bool destroyKey;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool GetDestroyedKey()
	{
		return destroyKey;
	}

	public void Unlock(int keyID)
	{
		if(lockID == keyID)
		{
			gameObject.SetActive(false);
		}
	}
}
