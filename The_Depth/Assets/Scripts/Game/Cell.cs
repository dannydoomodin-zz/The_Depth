using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	private cameraFollow camScript;
	private GameObject currentLookingObj;

	private GameObject doorObject;
	private bool animateDoor = false;
	private float deltaX;
	private const float doorOpenPosX = -1.5f;

	void unlockWithHealth(GameObject unlockObj)
	{
		PlayerProfile.instance.RemoveHealth(10);
		Debug.Log("current health: " + PlayerProfile.instance.GetCurrentHealth());
		unlock(unlockObj);
	}

	void setDoorUnlockAnimation()
	{

		deltaX = (doorObject.transform.localPosition.x - doorOpenPosX)/1;
		animateDoor = true;
		
		doorObject.collider.enabled = false;
	}

	void unlock(GameObject unlockObj)
	{
		string objName = unlockObj.name;
		if(objName == "cellDoor")
		{
			Debug.Log("door unlocked");
			Transform pointers = gameObject.transform.FindChild("CameraPointers");
			Transform pointer2 = pointers.FindChild("pointer2");
			pointer2.GetComponent<camPointer_script>().upBlocked = false;


			//set animation info
			doorObject = unlockObj;
			setDoorUnlockAnimation();

			cameraFollow camFollowScript = GameObject.Find ("Main Camera").GetComponent<cameraFollow>();
			camPointer_script pointerScript = camFollowScript.target.GetComponent<camPointer_script>();
			pointerScript.updateUI();
		}
	}

	// Use this for initialization
	void Start () {
		camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
		ArrayList list = new ArrayList();
		list.Add("Uhhh.....where am I?");
		list.Add("How did I get here?");
		list.Add("I remember the ship sinking.... the screaming...");
		list.Add("I need to get out of here....");
		Util.setDialogue(list);
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
					if (hit.transform.gameObject.name == "toilet")
					{
						currentLookingObj = hit.transform.gameObject;
						camScript.height = Constants.camHeight[(int)Constants.clickableScenes.toilet];
						hit.transform.collider.enabled = false;
						hit.transform.FindChild("toiletTop").collider.enabled = true;
					}
					else if(hit.transform.gameObject.name == "sink")
					{
						currentLookingObj = hit.transform.gameObject;
						camScript.height = Constants.camHeight[(int)Constants.clickableScenes.sink];
						hit.transform.collider.enabled = false;
					}
					else if(hit.transform.gameObject.name == "bedBottom")
					{
						currentLookingObj = hit.transform.gameObject;
						camScript.height = 0;
						hit.transform.collider.enabled = false;
					}
				}
				
				if(hit.transform.gameObject.name == "cellDoor")
				{
					if(InventoryManager.instance.FindById("cell_key"))
					{
						unlock(hit.transform.gameObject);
					}
					else
					{
						Debug.Log("The cell door is locked shut! I need to somehow get out...");
						Util.setDialogue("The cell door is locked shut! I could try force it open...", hit.transform.gameObject);
						Util.ShowChooserDialogue();
					}
				}
				else if(hit.transform.gameObject.name == "cell_key"
				        || hit.transform.gameObject.name == "cell_note3"
				        || hit.transform.gameObject.name == "cell_mirror")
				{
					hit.transform.SendMessage("AddToInventory");
				}
				else if( hit.transform.gameObject.name == "wall_mirror")
				{
					Util.setDialogue("Hmm... Someone needs to clean this dirty mirror...");
				}
				else if( hit.transform.gameObject.name == "skeleton")
				{
					if(InventoryManager.instance.FindById("cell_note1"))
					{
						Util.setDialogue("...");
					}
					else
					{
						Util.setDialogue("I need to get out or I'll end up like him...what's that beside him");
					}
				}
				else if( hit.transform.gameObject.name == "cell_note1")
				{
					hit.transform.SendMessage("AddToInventory");
					Util.setDialogue("I don't think he will be needing this....");
				}
				else if( hit.transform.gameObject.name == "cell_note2")
				{
					hit.transform.SendMessage("AddToInventory");
					Util.setDialogue("there should be another note.... where is it?");
				}

			}
		}
		else if(Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				Debug.Log(hit.transform.gameObject.name);
				
				if(hit.transform.gameObject.name == "cellDoor")
				{
					unlockWithHealth(hit.transform.gameObject);
				}
			}
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if(currentLookingObj)
			{
				if(currentLookingObj.name == "toilet")
				{
					currentLookingObj.transform.collider.enabled = true;
					currentLookingObj.transform.FindChild("toiletTop").collider.enabled = false;
				}
				else if(currentLookingObj.name == "bedBottom")
				{
					currentLookingObj.transform.collider.enabled = true;
				}
				else if(currentLookingObj.name == "sink")
				{
					currentLookingObj.transform.collider.enabled = true;
				}
				
				currentLookingObj = null;
			}
		}

	}

	void updateAnimation()
	{
		if(animateDoor)
		{
			if(doorObject.transform.localPosition.x > doorOpenPosX)
			{
				doorObject.transform.position = new Vector3(doorObject.transform.position.x - (deltaX * Time.deltaTime)
				                                            , doorObject.transform.position.y, doorObject.transform.position.z);
			}
			else
			{
				animateDoor = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateAnimation();
	}

	void LateUpdate () {
		updateInputs();
	}

	public void ForceUnlock(GameObject obj)
	{
		if(obj.name == "cellDoor")
		{
			unlockWithHealth(obj.transform.gameObject);
		}
	}
}
