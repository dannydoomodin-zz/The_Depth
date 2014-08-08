using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	public bool locked = false;
	public GameObject toRoom;
	public GameObject toPointer;

	// Use this for initialization
	void Start () {
		//determine if a door is locked
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Go()
	{
		if(!locked)
		{
			cameraFollow camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
			SceneManager.Scenes sceneEnum = SceneManager.instance.GetSceneEnumByName(toRoom.name);
			SceneManager.instance.HideAllScene(sceneEnum);
			SceneManager.instance.DisplayScene(sceneEnum);
			camScript.target = toPointer.transform;
		}
	}
}
