using UnityEngine;
using System.Collections;

public class debug : MonoBehaviour {

	public GameObject skipIntroHint;
	private float startTime = 0.0f;
	private bool one_click = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if(SceneManager.instance.GetCurrentScene() == SceneManager.Scenes.intro_cutscene || 
		   SceneManager.instance.GetCurrentScene() == SceneManager.Scenes.prologue)
		{
			//Skipping start scene
			if(Input.GetMouseButtonUp(0)) //left mouse btn
			{
				if(!one_click)
				{
					one_click = true;
					//show skip intro tag
					Debug.Log ("start timer");
					startTime = Time.time;
					if(skipIntroHint)
					{
						Util.setObjectActive(skipIntroHint);
					}
				}
				else
				{
					one_click = false;
					Debug.LogError("skipping intro");
					Application.LoadLevel("game");
				}
			}

			if(one_click && (Time.time - startTime > Constants.skipIntroDelay))
			{
				one_click = false;
				if(skipIntroHint)
				{
					skipIntroHint.SetActive(false);
				}
			}

		}
		else
		{
			//for debugging rooms
			cameraFollow camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
			bool processedInput = false;

			if(Input.GetKeyUp(KeyCode.Q))
			{
				if((int)(SceneManager.instance.GetCurrentScene() - 1) < Constants.DebugRoomLowerLimit)
				{
					return;
				}

				SceneManager.instance.HideAllScene(SceneManager.instance.GetCurrentScene() - 1);
				SceneManager.instance.DisplayScene(SceneManager.instance.GetCurrentScene() - 1);
				processedInput = true;
			}

			if(Input.GetKeyUp(KeyCode.W))
			{
				if((int)(SceneManager.instance.GetCurrentScene() + 1) > Constants.DebugRoomUpperLimit)
				{
					return;
				}

				SceneManager.instance.HideAllScene(SceneManager.instance.GetCurrentScene() + 1);
				SceneManager.instance.DisplayScene(SceneManager.instance.GetCurrentScene() + 1);

				processedInput = true;
			}

			if(processedInput)
			{
				GameObject sceneObj = GameObject.Find(SceneManager.instance.GetCurrentScene().ToString());
				Transform sceneTrans = sceneObj.transform.FindChild("CameraPointers");
				camScript.target = sceneTrans.GetChild(0);
				processedInput = false;
			}


		}
	}
}
