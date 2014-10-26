using UnityEngine;
using System.Collections;

public class CommandCentre : MonoBehaviour {

	private cameraFollow camScript;
	private GameObject currentLookingObj;

	// Use this for initialization
	void Start () {
		camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
	}
	
	// Update is called once per frame
	void Update () {
		updateInputs();
	}

	void unlockPlaquePanel(bool value)
	{
		var plaqueObj = transform.FindChild("Plaque");
		var plaqueBodyObj = plaqueObj.FindChild("PlaqueBody");
		var panelObj = plaqueBodyObj.FindChild("panelObj");
		panelObj.gameObject.SetActive(value);
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
				Transform ptr = hit.transform.FindChild("pointer");
				if(ptr)
				{
					Debug.Log("go to mouse pointer");
					camScript.target = ptr;
					if (hit.transform.gameObject.name == "panel")
					{
						currentLookingObj = hit.transform.gameObject;
						hit.transform.collider.enabled = false;
					}
				}
			}
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if(currentLookingObj)
			{
				if(currentLookingObj.name == "panel")
				{
					currentLookingObj.transform.collider.enabled = true;
				}
				
				currentLookingObj = null;
			}
		}
	}
}
