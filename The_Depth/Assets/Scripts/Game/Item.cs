using UnityEngine;
using System.Collections;

public class Item {
	
	public string m_id;
	public GameObject m_itemObj;
	public string m_description;
	public string m_ImageId;
		
	public Item(string id, GameObject itemObj, string imageId = null)
	{
		m_id = id; 
		m_itemObj = itemObj;
		m_description = GetItemDescription(m_id);
		m_ImageId = GetItemImage(m_id);
	}

	private string GetItemImage(string itemId)
	{
		if(itemId == "flashLight")
		{
			return "torchUI";
		}
		else if(itemId == "charcole")
		{
			return "charcoleUI";
		}
		else if(itemId == "paper")
		{
			return "paperUI";
		}
		else if(itemId == "knife1")
		{
			return "knifeUI";
		}
		else if(itemId == "TimeDevice")
		{
			return "timeDeviceUI";
		}	
		else if(itemId == "screwDriver")
		{
			return "screwdriverUI";
		}
		else if(itemId == "wrench1")
		{
			return "wrenchUI";
		}
		else if(itemId == "brokenBucket")
		{
			return "";
		}
		else if(itemId == "cell_mirror")
		{
			return "mirrorUI";
		}
		else if(itemId == "cell_key")
		{
			return "keyUI";
		}
		else if(itemId == "cell_note1")
		{
			return "cell_notes1";
		}
		else if(itemId == "cell_note2")
		{
			return "cell_notes2";
		}		
		else if(itemId == "cell_note3")
		{
			return "cell_notes3";
		}
		else if(itemId == "corkPieces")
		{
			return "";
		}
		else if(itemId == "Bucket")
		{
			return "bucketUI";
		}
		else if(itemId == "cork")
		{
			return "corkUI";
		}
		else if(itemId == "BucketWithFuel")
		{
			return "";
		}
		
		Debug.Log("item image not found");
		return "";
	}

	private string GetItemDescription(string itemId)
	{
		if(itemId == "flashLight")
		{
			return "normal looking flash light, seems to still work.";
		}
		else if(itemId == "charcole")
		{
			return "Just a normal piece of charcole.";
		}
		else if(itemId == "paper")
		{
			return "A blank piece of paper, maybe I could write something on this, if only I had a pencil.";
		}
		else if(itemId == "knife1")
		{
			return "Still sharp, could carve something or do some serious damage with this if I'm not careful.";
		}
		else if(itemId == "TimeDevice")
		{
			return "Some sort of device, there's a big button on it and a label that says \'time control\'... ";
		}	
		else if(itemId == "screwDriver")
		{
			return "A flimsy screw driver. Doesn't seems to be very strong. Probably will break easily.";
		}
		else if(itemId == "wrench1")
		{
			return "A metal normal wrench. Really cold to touch.";
		}
		else if(itemId == "brokenBucket")
		{
			return "A broken bucket, has a few holes in it. Doesn't seems to be very useful at carrying any liquid right now.";
		}
		else if(itemId == "cell_mirror")
		{
			return "Just a normal looking mirror.";
		}
		else if(itemId == "cell_key")
		{
			return "A key, I wonder what it unlocks...";
		}
		else if(itemId == "cell_note1")
		{
			return "A Note, it says: I've finally done it! They're still unaware what I am up to... I'll get out... and escape this place ... I've hidden it, in a safe place. Only I know.... They won't find it. Somewher you will use everyday.... It's right infront of you but you won't see it... It takes all the worst things from yo ubut never complains...";
		}
		else if(itemId == "cell_note2")
		{
			return "Another note, it says: If you want to leave then don't forget what comes FIRST. Only problem is that things are always not so simple. What it is I do not know. Prounced like fellow or hello. Learn to see things from a different angle. Look under it and you will find your answer.";
		}		
		else if(itemId == "cell_note3")
		{
			return "The note says: I think I'm going mad..., where am I? ... What is going on.... I remember hiding something somewhere. It was somewhere...go to sleep? Under? I need to get out! GET OUT.....";
		}
		else if(itemId == "corkPieces")
		{
			return "A bunch of ordinary cork pieces that I cut up using a knife.";
		}
		else if(itemId == "Bucket")
		{
			return "A bucket that has its holes plugged up with corks.";
		}
		else if(itemId == "cork")
		{
			return "A piece of cork from a wine bottle somewhere...Maybe it can be used to plug something else up?";
		}
		else if(itemId == "BucketWithFuel")
		{
			return "A bucket filled with fuel from the oil barrels.";
		}

		Debug.Log("item description not found");
		return "";
	}

}
