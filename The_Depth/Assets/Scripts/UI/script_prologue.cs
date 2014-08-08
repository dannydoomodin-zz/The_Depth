using UnityEngine;
using System.Collections;

public class script_prologue : Scene {

	public float scrollTextAnchorEnd = 0;

	private float deltaPosition = 0;

	private float deltaAlpha = 0;

	private float fadeOutDeltaAlpha = 0;

	private int newsPaperCount = 0;

	private bool isFadingOut = false;

	private float imageDuration = 0;

	private float currentImageDuration = 0;

	public script_prologue(GameObject baseObject, float duration, float textEnd, float fadeOutDuration, float fadeInDuration) : base(true)
	{
		float differenceAlpha = 1.0f; //cus fade from 0-1
		scrollTextAnchorEnd = textEnd;
		sceneObj = baseObject;

		//calculate alpha fade from 0-1
		Transform newspaperTrans = sceneObj.transform.FindChild("intro_newspapers");
		if(newspaperTrans)
		{
			deltaAlpha = differenceAlpha / fadeInDuration;
			imageDuration = duration/ newspaperTrans.childCount;
			currentImageDuration = imageDuration;
		}

		//scroll text
		GameObject scrollText = sceneObj.transform.FindChild("intro_scroll_text").gameObject;
		if(scrollText)
		{
			UIAnchor AnchorScript = scrollText.GetComponent<UIAnchor>();
			if(AnchorScript)
			{
				float originalPos = AnchorScript.relativeOffset.y;
				float difference = textEnd - originalPos;
				deltaPosition = difference / duration;
			}
		}

		fadeOutDeltaAlpha = differenceAlpha / fadeOutDuration;
	}

	public override void Init()
	{
		base.cutSceneFinished = false;
		base.cutScenePlaying = true;
	}

	// Update is called once per frame
	public override void Update () {
		if(base.cutScenePlaying)
		{
			//scroll text
			GameObject scrollText = sceneObj.transform.FindChild("intro_scroll_text").gameObject;
			if(scrollText)
			{
				UIAnchor AnchorScript = scrollText.GetComponent<UIAnchor>();
				Transform newspaperTrans = sceneObj.transform.FindChild("intro_newspapers");
				if(AnchorScript)
				{
					if(AnchorScript.relativeOffset.y <= scrollTextAnchorEnd)
					{

						AnchorScript.relativeOffset.y += (deltaPosition * Time.deltaTime);
					
						//fade in picture
						Transform child1 = newspaperTrans.GetChild(newsPaperCount);
						UISprite spriteScript = child1.GetComponent<UISprite>();
						if(spriteScript.alpha < 1.0f)
						{
							spriteScript.alpha += (deltaAlpha * Time.deltaTime);
						}

						currentImageDuration -= Time.deltaTime;
						if(currentImageDuration <= 0)
						{
							currentImageDuration = imageDuration; 
							newsPaperCount++;
						}

						if(newsPaperCount > 4)
						{
							newsPaperCount = 4;
						}
					}
					else
					{
						for(int count = 0; count < newspaperTrans.childCount; count++)
						{
							Transform child1 = newspaperTrans.GetChild(count);
							UISprite spriteScript = child1.GetComponent<UISprite>();
							spriteScript.alpha -= (fadeOutDeltaAlpha * Time.deltaTime);
						}
						
						//scroll text
						UILabel scrollTextLabel = scrollText.transform.GetComponent<UILabel>();
						scrollTextLabel.alpha -= (fadeOutDeltaAlpha * Time.deltaTime);

						if(scrollTextLabel.alpha <= 0)
						{
							Debug.Log("scroll text isn't rendered");
							base.cutScenePlaying = false;
							base.cutSceneFinished = true;
						}
					}
				}
			}
		}
	}
}
