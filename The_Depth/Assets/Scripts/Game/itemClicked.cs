using UnityEngine;
using System.Collections;

public class itemClicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddToInventory()
	{
		//play item collection audio if there is one
		if(gameObject.GetComponent<AudioSource>())
		{
			gameObject.GetComponent<AudioSource>().Play();
		}

		//disables all rendering and light
		if(gameObject.GetComponent<Renderer>())
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		if(gameObject.GetComponent<Light>())
		{
			gameObject.GetComponent<Light>().enabled = false;
		}

		for(int x = 0; x < transform.childCount; x++)
		{

			if(gameObject.transform.GetChild(x).GetComponent<Renderer>())
			{
				gameObject.transform.GetChild(x).GetComponent<Renderer>().enabled = false;
			}
			if(gameObject.transform.GetChild(x).GetComponent<Light>())
			{
				gameObject.transform.GetChild(x).GetComponent<Light>().enabled = false;
			}

		}
		gameObject.GetComponent<Collider>().enabled = false;

		//add to inventory
		Item i = new Item(gameObject.name, gameObject);
		InventoryManager.instance.AddItem(i);

		InventoryManager.instance.currentChooserItemId = gameObject.name;
		InventoryManager.instance.showCurrentItemDescription();
	}
}
