﻿using UnityEngine;
using System.Collections;

public class UIItemPanel : MonoBehaviour {

	public GameObject HUDitem;

	public string[] itemName;

	// Use this for initialization
	void OnClick () {
		if(HUDitem.activeInHierarchy)
		{
			HUDitem.SetActive(false);
		}
		else
		{
			HUDitem.SetActive(true);
			InventoryManager.instance.UpdateInventoryUI();
		}

		Util.clickedUI = true;
	}

}
