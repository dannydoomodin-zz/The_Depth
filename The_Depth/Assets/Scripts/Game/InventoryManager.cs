using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	private static InventoryManager s_Instance = null;

	public ArrayList itemList;
	
	public static InventoryManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				InventoryManager tmpInst = FindObjectOfType(typeof(InventoryManager)) as InventoryManager;
				if (tmpInst != null)
					tmpInst.Start();
				s_Instance = tmpInst;
				
				if (s_Instance == null && Application.isEditor)
					Debug.LogError("Could not locate a object. You have to have exactly one object in the scene.");
			}
			
			return s_Instance;
		}
	}

	public void RemoveItem(Item item)
	{
		itemList.Remove(item);
	}

	public void AddItem(Item item)
	{
		itemList.Add(item);
	}

	public void AddItemByName(string room, string id)
	{

	}

	public string getItemName(int id)
	{
		Item i = (Item)itemList[id];
		return i.m_id;
	}

	public GameObject FindById(string id)
	{
		for(int x = 0; x < itemList.Count; x++)
		{
			Item i = (Item)itemList[x];
			if(i.m_id == id)
			{
				return i.m_itemObj;
			}
		}

		return null;
	}

	public bool Combine(Item item1, Item item2)
	{
		return true;
	}

	public int GetNumberOfItems()
	{
		return itemList.Count;
	}

	// Use this for initialization
	void Start () {
		itemList = new ArrayList();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			//show inventory list
			Debug.Log("Current Inventory:");
			for(int x = 0 ; x<itemList.Count; x++)
			{
				Debug.Log(x + ". " + ((Item)itemList[x]).m_id);
			}
		}
	}
}
