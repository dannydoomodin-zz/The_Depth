using UnityEngine;
using System.Collections;

public class CommandCentre : MonoBehaviour {

	private cameraFollow camScript;
	private GameObject currentLookingObj;

	private bool plaqueFixed = false;

	// Use this for initialization
	void Start () {
		camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
	}
	
	// Update is called once per frame
	void Update () {
		updateInputs();
	}

	void setPlaqueFixed(bool value)
	{
		plaqueFixed = value;
		var plaqueObj = transform.FindChild("Plaque");
		var plaqueBodyObj = plaqueObj.FindChild("PlaqueBody");
		var circuitBoards = plaqueBodyObj.FindChild("CircuitBoards");
		var wrench1 = circuitBoards.FindChild("wrench1");
		wrench1.gameObject.SetActive(value);

		var plaqueButton = plaqueObj.FindChild("PlaqueButton");
		var buttonLight = plaqueButton.FindChild("buttonLight");
		buttonLight.gameObject.SetActive(value);
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

				
				if(hit.transform.gameObject.name == "panel" || hit.transform.gameObject.name == "bolt" )
				{
					Debug.Log("Looks like a panel hiding the circuit, maybe I can open it with a screwdriver");
					Util.setDialogue("Looks like a panel hiding the circuit, maybe I can open it with a screwdriver");
				}
				else if(hit.transform.gameObject.name == "circuit")
				{
					ArrayList list = new ArrayList();
					list.Add("The wire connecting the two poles are missing...");
					list.Add("..To get this plaque working again I need to connect them..");
					list.Add("Hmm anything metallic will do...");
					Util.setDialogue(list);
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
