using UnityEngine;
using System.Collections;

public class CommandCentre : MonoBehaviour {

	private cameraFollow camScript;
	private GameObject currentLookingObj;
	public GameObject subHullWindowObj;
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
				Transform ptr = hit.transform.FindChild("pointer");
				if(ptr)
				{
					Debug.Log("go to mouse pointer");
					camScript.target = ptr;
					if (hit.transform.gameObject.name == "panel")
					{
						currentLookingObj = hit.transform.gameObject;
						hit.transform.GetComponent<Collider>().enabled = false;
					}
					else if( hit.transform.gameObject.name == "frontTop" ||
					        hit.transform.gameObject.name == "frontBottom")
					{
						currentLookingObj = hit.transform.gameObject;
					}
				}

				
				if(hit.transform.gameObject.name == "panel" || hit.transform.gameObject.name == "bolt" )
				{
					Debug.Log("Looks like a panel hiding the circuit, maybe I can open it with a screwdriver");
					Util.setDialogue("Looks like a panel hiding the circuit, maybe I can open it with a screwdriver");
				}
				else if(hit.transform.gameObject.name == "circuit" && !plaqueFixed)
				{
					if(ProgressManager.instance.isEngineStarted())
					{
						ArrayList list = new ArrayList();
						list.Add("The wire connecting the two poles are missing...");
						list.Add("..To get this plaque working again I need to connect them..");
						list.Add("Hmm anything metallic will do...");
						Util.setDialogue(list);
					}
					else
					{
						Debug.Log("There doesn't seem to be any power... Time to check the generator...");
						Util.setDialogue("There doesn't seem to be any power... Time to check the generator...");
					}
				}
				else if((hit.transform.gameObject.name == "button" ||
				         hit.transform.gameObject.name == "buttonBase") && plaqueFixed && ProgressManager.instance.isEngineStarted())
				{
					subHullWindowObj.SendMessage("StartAnimation");
				}
			}


		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if(currentLookingObj)
			{
				if(currentLookingObj.name == "panel")
				{
					currentLookingObj.transform.GetComponent<Collider>().enabled = true;
				}
				
				currentLookingObj = null;
			}
		}
		else if( Input.GetKeyDown(KeyCode.Space))
		{
			subHullWindowObj.SendMessage("StartAnimation");
		}
	}
}
