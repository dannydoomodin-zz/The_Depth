using UnityEngine;
using System.Collections;

public class Item {
	
	public string m_id;
	public GameObject m_itemObj;
		
	public Item(string id, GameObject itemObj)
	{
		m_id = id; 
		m_itemObj = itemObj;
	}

}
