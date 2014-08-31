using UnityEngine;
using System.Collections;

public class UseItem : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		if(gameObject.GetComponentInChildren<UILabel>().text.Length == 0)
		{
			return;
		}
		Util.ShowChooserDialogue(Util.chooserDialogueType.ItemAction);
		InventoryManager.instance.currentChooserItemId = gameObject.transform.FindChild("Label").GetComponent<UILabel>().text;
	}
}
