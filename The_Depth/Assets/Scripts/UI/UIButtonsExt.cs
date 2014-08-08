using UnityEngine;
using System.Collections;

public class UIButtonsExt : MonoBehaviour {

	public GameObject objToInvoke;
	public string methodToInvoke;
	public int param;

	void OnClick ()
	{
		objToInvoke.SendMessage(methodToInvoke, param, SendMessageOptions.DontRequireReceiver);
		Util.clickedUI = true;
		//scriptToInvoke.Invoke(methodToInvoke, 0);
	}
}
