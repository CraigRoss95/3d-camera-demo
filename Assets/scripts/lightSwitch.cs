using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour {

public GameObject sun;
public GameObject playerLightSource;
public GameObject playerCamLightSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<toggle>().GetOn())
		{
			sun.SetActive(true);
			playerLightSource.SetActive(false);
			playerCamLightSource.SetActive(false);
			RenderSettings.ambientIntensity = 1.0f;
			RenderSettings.reflectionIntensity = 1.0f;

		}
		else
		{
			sun.SetActive(false);
			playerLightSource.SetActive(true);
			playerCamLightSource.SetActive(true);
			RenderSettings.ambientIntensity = 0.0f;
			RenderSettings.reflectionIntensity = 0.0f;
		}
		
	}
}
