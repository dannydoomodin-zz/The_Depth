using UnityEngine;
using System.Collections;

public class Airlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
			
				if(hit.transform.gameObject.name == "TimeDevice")
				{
					hit.transform.SendMessage("AddToInventory");
				}

				if(hit.transform.gameObject.name == "OutDoor")
				{
					Util.setDialogue("Can't open it something seems to be blocking the way...");
				}
				
			}
		}
	}
}
