﻿using UnityEngine;
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
		string objId = gameObject.transform.FindChild("Label").GetComponent<UILabel>().text;
		Debug.Log("using: " + objId);
		InventoryManager.instance.UseItem(objId);
	}
}
