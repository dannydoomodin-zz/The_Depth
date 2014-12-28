
using UnityEngine;
using System.Collections;

public class DivingRoom : MonoBehaviour {

	private GameObject roomLight;
	private float secToNextFlash;

	// Use this for initialization
	void Start () 
	{
		roomLight = transform.FindChild("Point light").gameObject;
		secToNextFlash = 0.5f;
	}

	void LateUpdate()
	{
		if(InventoryManager.instance.FindById("flashLight") != null)
		{
			roomLight.SetActive(false);
			return;
		}
		if(secToNextFlash < 0)
		{
			secToNextFlash = ((float)Random.Range(2, 10))/10f;
			Debug.Log(secToNextFlash);
			if(roomLight.activeSelf)
			{
				roomLight.SetActive(false);
			}
			else
			{
				roomLight.SetActive(true);
			}

		}
		else
		{
			float deltaTime = Time.deltaTime;
			secToNextFlash -= deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {

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

				if(hit.transform.gameObject.name.Contains("Locker"))
				{
					Animation anim = hit.transform.gameObject.animation;
					AudioSource audio = hit.transform.gameObject.audio;
					if(!anim)
					{
						anim = hit.transform.parent.animation;
					}

					if(!audio)
					{
						audio = hit.transform.parent.audio;
					}

					if(anim)
					{
						anim.Play ("Open");
					}

					if(audio)
					{
						audio.Play();
					}
				}

				if(hit.transform.gameObject.name.Contains("flashLight"))
				{
					hit.transform.SendMessage("AddToInventory");
					Util.setDialogue("guess that light finally gave out... now I can't see anything");
				}
				else
				{
					hit.transform.SendMessage("AddToInventory");
				}

			}
		}
	}
}