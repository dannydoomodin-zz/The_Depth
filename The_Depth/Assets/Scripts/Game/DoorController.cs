using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool locked = false;
	public GameObject toRoom;
	public GameObject toPointer;
	private Color origAmbColour = new Color(0.2f,0.2f,0.2f);

	// Use this for initialization
	void Start () {
		//determine if a door is locked
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Go()
	{
		StartCoroutine(SwitchScene());
	}

	IEnumerator SwitchScene() {

		if(!locked)
		{
			gameObject.audio.Play();

			if(gameObject.audio.isPlaying)
			{
				yield return new WaitForSeconds(1);
			}

			cameraFollow camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
			SceneManager.Scenes sceneEnum = SceneManager.instance.GetSceneEnumByName(toRoom.name);
			SceneManager.instance.HideAllScene(sceneEnum);
			SceneManager.instance.DisplayScene(sceneEnum);
			camScript.target = toPointer.transform;
			camScript.isDoorTransition = true;
			
			if(sceneEnum == SceneManager.Scenes.DivingRoom || sceneEnum == SceneManager.Scenes.Airlock)
			{
				RenderSettings.ambientLight = new Color(0,0,0);
			}
			else
			{
				RenderSettings.ambientLight = origAmbColour;
			}
		}
	}
}
