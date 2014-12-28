using UnityEngine;
using System.Collections;

public class EngineRoom : MonoBehaviour {

	private cameraFollow camScript;
	private GameObject currentLookingObj;
	public bool engineHasFuel = false;
	public LightsMiniGame lightsMiniGame_script;

	// Use this for initialization
	void Start () {
		camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
	}

	public void setEngineFuelState(bool state)
	{
		engineHasFuel = state;
		if(lightsMiniGame_script)
		{
			lightsMiniGame_script.setLight(0);
			lightsMiniGame_script.canPlayLightsMiniGame = true;
		}
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
				Transform ptr = hit.transform.FindChild("pointer");
				if(ptr)
				{
					Debug.Log("go to mouse pointer");
					camScript.target = ptr;
					if (hit.transform.gameObject.name == "crate_1_crate_1_crate_1")
					{
						currentLookingObj = hit.transform.gameObject;
						camScript.height = Constants.camHeight[(int)Constants.clickableScenes.crate1];
						hit.transform.collider.enabled = false;
					}
				}

				if(hit.transform.gameObject.name == "screwDriver"
				   || hit.transform.gameObject.name == "wrench1")
				{
					hit.transform.SendMessage("AddToInventory");
				}

			}
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if(currentLookingObj)
			{
				if(currentLookingObj.name == "crate_1_crate_1_crate_1")
				{
					currentLookingObj.transform.collider.enabled = true;
				}
				
				currentLookingObj = null;
			}
		}
	}
}
