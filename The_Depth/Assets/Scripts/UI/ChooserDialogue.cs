using UnityEngine;
using System.Collections;

public class ChooserDialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick ()
	{
		if(gameObject.name == "OkButton")
		{
			int currentSceneNo = (int)SceneManager.instance.GetCurrentScene();
			GameObject obj = SceneManager.instance.sceneObjs[currentSceneNo];
			obj.SendMessage("ForceUnlock", Util.dialogueObj);
		}

		Util.clickedUI = true;
		Util.HideDialogue();
		Util.HideChooserDialogue();
	}
}
