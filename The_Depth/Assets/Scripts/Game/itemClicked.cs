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
		/*if(gameObject.renderer)
		{
			gameObject.renderer.enabled = false;
		}	
		else
		{
			for(int count = 0; count < gameObject.transform.childCount; count++)
			{
				if(gameObject.transform.GetChild(count).renderer)
				{
					gameObject.transform.GetChild(count).renderer.enabled = false;
				}
			}
		}
		gameObject.collider.enabled = false;*/
		gameObject.SetActive(false);
		Item i = new Item(gameObject.name, gameObject);
		InventoryManager.instance.AddItem(i);
	}
}
