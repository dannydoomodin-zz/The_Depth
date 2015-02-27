using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform currentPosition;

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyUp(KeyCode.LeftArrow))
		{
			turnLeft();
		}
		
		if(Input.GetKeyUp(KeyCode.RightArrow))
		{
			turnRight();
		}
		
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			turnUp();
		}
		
		if(Input.GetKeyUp(KeyCode.DownArrow))
		{
			turnDown();
		}
	}

	public void turnRight()
	{   
		var camFollow = this.GetComponent<cameraFollow> ();
		currentPosition = camFollow.target;
		camFollow.enabled = false;
		currentPosition.GetComponent<camPointer_script>().goRight();
	}

	public void turnLeft()
	{
		var camFollow = this.GetComponent<cameraFollow> ();
		currentPosition = camFollow.target;
		camFollow.enabled = false;
		currentPosition.GetComponent<camPointer_script>().goLeft();
	}

	public void turnUp()
	{
		var camFollow = this.GetComponent<cameraFollow> ();
		currentPosition = camFollow.target;
		camFollow.enabled = false;
		currentPosition.GetComponent<camPointer_script>().goUp();
	}

	public void turnDown()
	{
		var camFollow = this.GetComponent<cameraFollow> ();
		currentPosition = camFollow.target;
		camFollow.enabled = false;
		currentPosition.GetComponent<camPointer_script>().goDown();
	}

	public void focusOnObject()
	{
		var cameraScript = gameObject.GetComponent<cameraFollow> ();
		cameraScript.enabled = true;
	}
}
