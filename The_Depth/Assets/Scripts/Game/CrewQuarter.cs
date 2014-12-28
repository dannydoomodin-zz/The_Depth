using UnityEngine;
using System.Collections;

public class CrewQuarter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		updateInputs();
	}

	void updateInputs()
	{
		if(UICamera.hoveredObject != null)
		{
			return;
		}

		if(Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				Debug.Log(hit.transform.gameObject.name);

				if(hit.transform.gameObject.name == "charcole"
				   || hit.transform.gameObject.name == "paper")
				{
					hit.transform.SendMessage("AddToInventory");
				}
			}
		}
		
	}
}
