using UnityEngine;
using System.Collections;

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

	public GameObject colliderObj;

	// Use this for initialization
	void Start () {
		camScript = GameObject.Find ("Main Camera").transform.GetComponent<cameraFollow>();
		updateUI();
	}

	public void goLeft()
	{
		if(Left && !leftBlocked)
		{
			Debug.Log("go left");
			camScript.target = Left.transform;
			camScript.height = LeftCamHeight;
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
			Debug.Log("go right");
			camScript.target = Right.transform;
			camScript.height = RightCamHeight;
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
			updateUI();
		}
		else
		{
			Debug.Log("no cam pointer");
		}
	}
	
	// Update ui
	public void updateUI () {
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
