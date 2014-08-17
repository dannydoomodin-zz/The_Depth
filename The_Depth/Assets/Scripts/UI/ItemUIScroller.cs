using UnityEngine;
using System.Collections;

public class ItemUIScroller : MonoBehaviour {

	public bool isLeft;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick()
	{
		int currentPage = InventoryManager.instance.getCurrentPage();
		if(isLeft)
		{
			InventoryManager.instance.setCurrentPage(currentPage-1);
		}
		else
		{
			InventoryManager.instance.setCurrentPage(currentPage+1);
		}

		InventoryManager.instance.UpdateInventoryUI();
	}
}
