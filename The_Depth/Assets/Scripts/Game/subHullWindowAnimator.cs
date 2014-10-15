using UnityEngine;
using System.Collections;

public class subHullWindowAnimator : MonoBehaviour {

	private ArrayList AnimateObj;
	private ArrayList WindowObjs;
	public float[] triggerPos;
	public Transform finishPos;
	public float time = 0.05f;
	private bool start = false;
	private int currentTackPanel = 0;

	// Use this for initialization
	void Start () {
		WindowObjs = new ArrayList();
		AnimateObj = new ArrayList();


		for(int x = 0; x < gameObject.transform.childCount; x++)
		{
			var child = gameObject.transform.GetChild(x);
			WindowObjs.Add(child);
		}

		AnimateObj.Add(WindowObjs[WindowObjs.Count -1]);
		WindowObjs.RemoveAt(WindowObjs.Count -1);
	}
	
	// Update is called once per frame
	void Update () {
		var tempArrayList = AnimateObj;

		if(Input.GetKeyDown(KeyCode.Space))
		{
			start = true;
		}

		if(start)
		{
			for(int x = 0; x< AnimateObj.Count ; x++)
			{
				var animObj = AnimateObj[x] as Transform;

				if(Mathf.Abs(animObj.position.y - finishPos.position.y) < 10)
				{
					continue;
				}

				var posY = Mathf.Lerp(animObj.position.y, finishPos.position.y, time * Time.deltaTime);
				animObj.position = new Vector3(animObj.position.x,posY, animObj.position.z);
				Debug.Log("panel:" + x+ "posY:" + posY);
				if(WindowObjs.Count > 0)
				{
					if(x == currentTackPanel && Mathf.Abs(animObj.position.y - triggerPos[x])  <1)
					{
						tempArrayList.Add(WindowObjs[WindowObjs.Count -1]);
						WindowObjs.RemoveAt(WindowObjs.Count -1);
						currentTackPanel++;
					}
				}
			}

			AnimateObj = tempArrayList;
		}
	}
}
