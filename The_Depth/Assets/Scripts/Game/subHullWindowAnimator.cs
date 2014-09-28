using UnityEngine;
using System.Collections;

public class subHullWindowAnimator : MonoBehaviour {

	private Transform AnimateObj;
	private ArrayList WindowObjs;
	public Transform finishPos;
	public float time = 0.05f;
	private bool start = false;

	// Use this for initialization
	void Start () {
		WindowObjs = new ArrayList();

		for(int x = 0; x < gameObject.transform.childCount; x++)
		{
			var child = gameObject.transform.GetChild(x);
			WindowObjs.Add(child);
		}

		AnimateObj = WindowObjs[WindowObjs.Count -1] as Transform;
		WindowObjs.RemoveAt(WindowObjs.Count -1);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			start = true;
		}

		if(start)
		{
			var posY = Mathf.Lerp(AnimateObj.position.y, finishPos.position.y, time * Time.deltaTime);
			AnimateObj.position = new Vector3(AnimateObj.position.x,posY, AnimateObj.position.z);

			if(WindowObjs.Count > 0)
			{
				if(Mathf.Abs(AnimateObj.position.y - finishPos.position.y)  <10)
				{
					AnimateObj = WindowObjs[WindowObjs.Count -1] as Transform;
					WindowObjs.RemoveAt(WindowObjs.Count -1);
				}
			}
		}
	}
}
