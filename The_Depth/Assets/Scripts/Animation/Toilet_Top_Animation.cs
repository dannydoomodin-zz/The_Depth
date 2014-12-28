using UnityEngine;
using System.Collections;

public class Toilet_Top_Animation : MonoBehaviour {

	public float smooth = 2.0f;
	public float tiltAngle = -90.0f;
	public bool startAnimation = false;
	public Quaternion target;

	void Update()
	{
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

				if(hit.transform.gameObject.name == "toilet_top")
				{
					startAnimation = true;
					transform.collider.enabled = false;
				}
			}
		}

		if(startAnimation)
		{
			var target = Quaternion.Euler(tiltAngle,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z );
			// Dampen towards the target rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		}
	}
}
