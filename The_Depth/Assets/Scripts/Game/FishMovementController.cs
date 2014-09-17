using UnityEngine;
using System.Collections;

public class FishMovementController : MonoBehaviour {

	public Transform target = null;
	private Vector3 originalPos;
	// Use this for initialization
	void Start () {
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float distance=Vector3.Distance(transform.position, target.position);
		if(distance>50){
			transform.position = Vector3.Lerp (
				transform.position, target.position,
				Time.deltaTime * 0.1f);
		}
		else
		{
			transform.position = originalPos;
		}
	}
}
