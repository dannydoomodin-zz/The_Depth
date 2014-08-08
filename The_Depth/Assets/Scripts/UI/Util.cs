using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

	public static bool clickedUI = false;

	public static void setObjectActive(GameObject obj)
	{
		if(!obj.activeSelf)
		{
			obj.SetActive(true);
		}
		
		for( int count = 0; count < obj.transform.childCount ; count++)
		{
			setObjectActive(obj.transform.GetChild(count).gameObject);
		} 
	}

	public static void setDialogue(string s)
	{
		GameObject dialogueBase = GameObject.Find("DialogueBase");
		if(dialogueBase)
		{
			if(s.Length == 0)
			{
				for(int x = 0; x < dialogueBase.transform.childCount; x++) //set childs inactive
				{
					dialogueBase.transform.GetChild(x).gameObject.SetActive(false);
				}
			}
			else
			{
				for(int x = 0; x < dialogueBase.transform.childCount; x++) //set childs inactive
				{
					dialogueBase.transform.GetChild(x).gameObject.SetActive(true);
				}

				Transform text = dialogueBase.transform.FindChild("DialogueText");
				UILabel label = text.GetComponent<UILabel>();
				label.text = s;
				
			}
		}
	}

	public static void HideDialogue()
	{
		setDialogue("");
	}
	
}
