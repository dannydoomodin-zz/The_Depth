using UnityEngine;
using System.Collections;

public class Pillow_Animation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float smooth = 2.0f;
	public float tiltAngle = -90.0f;
	public bool startAnimation = false;
	public Quaternion target;

	void StartAnimation()
	{
		startAnimation = true;
		transform.GetComponent<Collider>().enabled = false;
	}

	void Update()
	{	
		if(startAnimation)
		{
			var target = Quaternion.Euler(tiltAngle,transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z );
			// Dampen towards the target rotation
			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		}
	}
}
