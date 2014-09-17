using UnityEngine;
using System.Collections;

public class UnderwaterScript : MonoBehaviour {
	
	//This script enables underwater effects. Attach to main camera.
	
	//Define variable
	public int underwaterLevel = 7;
	public float fogDensity = 0.04f;

	//The scene's default fog settings
	private bool defaultFog;
	private Color defaultFogColor;
	private float defaultFogDensity;
	private Material defaultSkybox;
	private Material noSkybox;
	
	void Start () {
		//Set the background color
		defaultFog = RenderSettings.fog;
		defaultFogColor = RenderSettings.fogColor;
		defaultFogDensity = RenderSettings.fogDensity;
		defaultSkybox = RenderSettings.skybox;
		camera.backgroundColor = new Color(0.06666f, 0.06666f, 0.14117647f, 1);
	}
	
	void Update () {
		if (transform.position.y < underwaterLevel)
		{
			RenderSettings.fog = true;
			RenderSettings.fogColor = new Color(.06666f, 0.06666f, 0.14117647f, 0.6f);
			RenderSettings.fogDensity = fogDensity;
			RenderSettings.skybox = noSkybox;
		}
		else
		{
			RenderSettings.fog = defaultFog;
			RenderSettings.fogColor = defaultFogColor;
			RenderSettings.fogDensity = defaultFogDensity;
			RenderSettings.skybox = defaultSkybox;
		}
	}
}