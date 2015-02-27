using UnityEngine;
using System.Collections;
using SWS;

public class camPointer_script : MonoBehaviour {

	public GameObject Left;
	public GameObject Down;
	public GameObject Up;
	public GameObject Right;

	public bool leftBlocked;
	public bool downBlocked;
	public bool upBlocked;
	public bool rightBlocked;

	public float LeftCamHeight;
	public float DownCamHeight;
	public float UpCamHeight;
	public float RightCamHeight;

	private cameraFollow camScript;
	private splineMove pathScript;

	public PathManager waypointPathL;
	public PathManager waypointPathD;
	public PathManager waypointPathU;
	public PathManager waypointPathR;

	public GameObject colliderObj;

	// Use this for initialization
	void Start () {
		initialiseScripts();
		updateUI();
	}

	public void initialiseScripts()
	{
		GameObject mainCam = GameObject.Find ("Main Camera");
		if(camScript == null)
		{
			camScript = mainCam.transform.GetComponent<cameraFollow>();
		}

		if (pathScript == null) 
		{
			pathScript = mainCam.transform.GetComponent<splineMove> ();
		}
	}

	public void setPathInfo(int numberOfWaypoint)
	{
		pathScript.messages.list.Clear();
		pathScript.messages.Initialize(numberOfWaypoint);
		var lastWaypoint = pathScript.messages.GetMessageOption(numberOfWaypoint -1);
		
		lastWaypoint.message = new System.Collections.Generic.List<string>(){"focusOnObject"};
		lastWaypoint.obj = new System.Collections.Generic.List<Object>(){GameObject.Find ("Main Camera")};
		lastWaypoint.type = new System.Collections.Generic.List<MessageOptions.ValueType>(){MessageOptions.ValueType.Object};

		pathScript.ResetMove();
		pathScript.StartMove();
	}

	public void goLeft()
	{
		if(Left && !leftBlocked)
		{
			initialiseScripts();
			Debug.Log("go left");
			camScript.target = Left.transform;
			pathScript.pathContainer = waypointPathL;
			setPathInfo(waypointPathL.waypoints.Length);
			updateUI();
		}
		else
		{
			Debug.Log("no cam pointer");
		}
	}

	public void goRight()
	{
		if(Right && !rightBlocked)
		{
			initialiseScripts();
			Debug.Log("go right");
			camScript.target = Right.transform;
			camScript.height = RightCamHeight;
			pathScript.pathContainer = waypointPathR;
			setPathInfo(waypointPathR.waypoints.Length);
			updateUI();
		}
		else
		{
			Debug.Log("no cam pointer");
		}
	}

	public void goUp()
	{
		if(Up && !upBlocked)
		{
			Debug.Log("go up");
			camScript.target = Up.transform;
			camScript.height = UpCamHeight;
			pathScript.pathContainer = waypointPathU;
			setPathInfo(waypointPathU.waypoints.Length);
			updateUI();
		}
		else
		{
			Debug.Log("no cam pointer");
		}
	}

	public void goDown()
	{
		if(Down && !downBlocked)
		{
			Debug.Log("go down");
			camScript.target = Down.transform;
			camScript.height = DownCamHeight;
			pathScript.pathContainer = waypointPathD;
			setPathInfo(waypointPathD.waypoints.Length);
			updateUI();
		}
		else
		{
			Debug.Log("no cam pointer");
		}
	}
	
	// Update ui
	public void updateUI () {
		if (camScript == null) {
			camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>(); //TODO: find out why this could be null
		}

		camPointer_script script = camScript.target.GetComponent<camPointer_script>();

		Transform btnUp = GameObject.Find("HUD").transform.FindChild("BtnUp");
		Transform btnDown = GameObject.Find("HUD").transform.FindChild("BtnDown");
		Transform btnLeft = GameObject.Find("HUD").transform.FindChild("BtnLeft");
		Transform btnRight = GameObject.Find("HUD").transform.FindChild("BtnRight");

		btnUp.gameObject.SetActive(false);
		btnDown.gameObject.SetActive(false);
		btnLeft.gameObject.SetActive(false);
		btnRight.gameObject.SetActive(false);

		if(script.Up && !script.upBlocked)
		{
			btnUp.gameObject.SetActive(true);
		}

		if(script.Left && !script.leftBlocked)
		{
			btnLeft.gameObject.SetActive(true);
		}

		if(script.Right && !script.rightBlocked)
		{
			btnRight.gameObject.SetActive(true);
		}

		if(script.Down && !script.downBlocked)
		{
			btnDown.gameObject.SetActive(true);
		}

		//reenable collider objs
		if(colliderObj)
		{
			colliderObj.collider.enabled = true;
		}
	}
}
