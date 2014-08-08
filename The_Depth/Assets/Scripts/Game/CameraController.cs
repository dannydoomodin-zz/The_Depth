using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	private Transform currentPosition;

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
		currentPosition = this.GetComponent<cameraFollow>().target;
		currentPosition.GetComponent<camPointer_script>().goRight();
	}

	public void turnLeft()
	{
		currentPosition = this.GetComponent<cameraFollow>().target;
		currentPosition.GetComponent<camPointer_script>().goLeft();
	}

	public void turnUp()
	{
		currentPosition = this.GetComponent<cameraFollow>().target;
		currentPosition.GetComponent<camPointer_script>().goUp();
	}

	public void turnDown()
	{
		currentPosition = this.GetComponent<cameraFollow>().target;
		currentPosition.GetComponent<camPointer_script>().goDown();
	}

}
