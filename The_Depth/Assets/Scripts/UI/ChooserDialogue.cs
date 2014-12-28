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
		else if(gameObject.name == "UseButton")
		{
			Debug.Log("using: " + InventoryManager.instance.currentChooserItemId);
			InventoryManager.instance.UseItem(InventoryManager.instance.currentChooserItemId);
		}
		else if(gameObject.name == "CombineButton")
		{
			Debug.Log("selected:" + gameObject.name);
			if(InventoryManager.instance.itemToCombineWith.Length == 0 &&
			   InventoryManager.instance.itemToCombineWith2.Length == 0)
			{
				InventoryManager.instance.itemToCombineWith2 = InventoryManager.instance.currentChooserItemId;
				Debug.Log("choose another item to combine with");
			}
			else 
			{
				InventoryManager.instance.itemToCombineWith = InventoryManager.instance.currentChooserItemId;
				InventoryManager.instance.CombineCurrentSelection();
			}
		}
		else if(gameObject.name == "InvestigateButton")
		{
			InventoryManager.instance.showCurrentItemDescription();
			Debug.Log("TODO: show item details");
		}

		Util.HideDialogue();
		Util.HideChooserDialogue();
	}
}
