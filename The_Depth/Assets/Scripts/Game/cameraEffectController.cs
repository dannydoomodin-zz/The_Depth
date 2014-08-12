using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class cameraEffectController : MonoBehaviour {

	private bool isUsingTDevice = false;

	public Shader shader;
	public void Awake() 
	{
		if (shader)
		{
			transform.camera.SetReplacementShader(shader, null);
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.D))
		{
			if(isUsingTDevice)
			{
				isUsingTDevice = false;
				transform.camera.SetReplacementShader(shader, null);
			}
			else
			{
				isUsingTDevice = true;
				transform.camera.SetReplacementShader(null, null);
			}
		}
	}
}
