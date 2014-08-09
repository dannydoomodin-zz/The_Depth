using UnityEngine;
using System.Collections;

public class DialogueControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick ()
	{
		Util.clickedUI = true;
		Util.HideDialogue();
		Util.HideChooserDialogue();
	}
}
