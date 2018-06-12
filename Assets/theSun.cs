using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theSun : MonoBehaviour {

public GameObject playerLightSource;
public GameObject playerCamLightSource;

	// Use this for initialization
	void Start () {
			gameObject.SetActive(true);
			playerLightSource.SetActive(false);
			playerCamLightSource.SetActive(false);
			RenderSettings.ambientIntensity = 1.0f;
			RenderSettings.reflectionIntensity = 1.0f;

	}
	public void Switch()
	{
			if(gameObject.active == false)
		{
			gameObject.SetActive(true);
			playerLightSource.SetActive(false);
			playerCamLightSource.SetActive(false);
			RenderSettings.ambientIntensity = 1.0f;
			RenderSettings.reflectionIntensity = 1.0f;

		}
		else
		{
			gameObject.SetActive(false);
			playerLightSource.SetActive(true);
			playerCamLightSource.SetActive(true);
			RenderSettings.ambientIntensity = 0.0f;
			RenderSettings.reflectionIntensity = 0.0f;
		}
	}
	// Update is called once per frame
	void Update () {
	
		
	}
}
