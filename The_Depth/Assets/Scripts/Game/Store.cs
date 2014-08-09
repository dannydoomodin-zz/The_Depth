﻿using UnityEngine;
using System.Collections;

public class Store : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		updateInputs();
	}
	
	void updateInputs()
	{
		if(Util.clickedUI)
		{
			Util.clickedUI = false;
			return;
		}

		if(Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				Debug.Log(hit.transform.gameObject.name);

				if(hit.transform.gameObject.name == "bucket")
				{
					hit.transform.SendMessage("AddToInventory");
				}
			}
		}
		
	}
}