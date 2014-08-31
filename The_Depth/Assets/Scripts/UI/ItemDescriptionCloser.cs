using UnityEngine;
using System.Collections;

public class ItemDescriptionCloser : MonoBehaviour {


	void OnClick ()
	{
		InventoryManager.instance.hideCurrentItemDescription();
	}
}