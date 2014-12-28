using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {
	
	public static GameObject dialogueObj = null;

	private static ArrayList multipleDialogues = null;

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

	public static void nextDialogue()
	{
		if(multipleDialogues.Count != 0)
		{
			setDialogueInt((string)multipleDialogues[0]);
			multipleDialogues.RemoveAt(0);
		}
		else
		{
			Util.HideDialogue();
			Util.HideChooserDialogue();
		}

	}

	public static void setDialogue(string s, GameObject obj = null)
	{
		ArrayList list = new ArrayList();
		list.Add(s);
		setDialogue(list, obj);
		dialogueObj = obj;
	}

	public static void setDialogue(ArrayList s, GameObject obj = null)
	{
		multipleDialogues = s;
		nextDialogue();
	}

	private static void setDialogueInt(string s, GameObject obj = null)
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

	public static void HideChooserDialogue()
	{
		GameObject ChooserDialogue = GameObject.Find("ChooserDialogue");
		if(ChooserDialogue)
		{
			for(int x = 0; x < ChooserDialogue.transform.childCount; x++) //set childs inactive
			{
				ChooserDialogue.transform.GetChild(x).gameObject.SetActive(false);
			}
		}
	}

	public enum chooserDialogueType
	{
		YesNo,
		ItemAction,
	};

	public static void ShowChooserDialogue(chooserDialogueType type = chooserDialogueType.YesNo)
	{
		GameObject ChooserDialogue = GameObject.Find("ChooserDialogue");
		if(ChooserDialogue)
		{
			if(type == chooserDialogueType.YesNo)
			{
				ChooserDialogue.transform.GetChild(0).gameObject.SetActive(true);
			}
			else
			{
				ChooserDialogue.transform.GetChild(1).gameObject.SetActive(true);
			}
		}
	}
}
