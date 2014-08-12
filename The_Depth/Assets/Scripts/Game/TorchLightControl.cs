using UnityEngine;
using System.Collections;

public class TorchLightControl : MonoBehaviour {

	private bool isTorchOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T))
		{
			if(isTorchOn)
			{
				isTorchOn = false;
			}
			else
			{
				isTorchOn = true;
			}
		}

		if(isTorchOn)
		{
			Debug.Log("torching aiming...");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				Vector3 hitPoint = hit.point;
				gameObject.transform.LookAt(hitPoint);
			}
		}
	}
}
