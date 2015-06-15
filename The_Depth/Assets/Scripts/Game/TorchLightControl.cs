using UnityEngine;
using System.Collections;

public class TorchLightControl : MonoBehaviour {

	public bool isTorchOn = false;

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
			//Debug.Log("torching aiming...");
			gameObject.GetComponent<Light>().enabled = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if(Physics.Raycast(ray, out hit, 100))
			{
				Vector3 hitPoint = hit.point;
				gameObject.transform.LookAt(hitPoint);
			}
		}
		else
		{
			gameObject.GetComponent<Light>().enabled = false;
		}
	}
}
