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
		if(gameObject.audio)
		{
			gameObject.audio.Play();
		}

		//disables all rendering and light
		if(gameObject.renderer)
		{
			gameObject.renderer.enabled = false;
		}
		if(gameObject.light)
		{
			gameObject.light.enabled = false;
		}

		for(int x = 0; x < transform.childCount; x++)
		{

			if(gameObject.transform.GetChild(x).renderer)
			{
				gameObject.transform.GetChild(x).renderer.enabled = false;
			}
			if(gameObject.transform.GetChild(x).light)
			{
				gameObject.transform.GetChild(x).light.enabled = false;
			}

		}
		gameObject.collider.enabled = false;

		//add to inventory
		Item i = new Item(gameObject.name, gameObject);
		InventoryManager.instance.AddItem(i);

		InventoryManager.instance.currentChooserItemId = gameObject.name;
		InventoryManager.instance.showCurrentItemDescription();
	}
}
