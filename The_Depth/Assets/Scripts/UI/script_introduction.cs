using UnityEngine;
using System.Collections;

public class script_introduction : Scene {

	private float fadeDurations;
	private float[] eachImageDuration;
	private float currentImageDuration = 0;
	private int currentImage = 0;
	private float deltaAlpha = 0;

	public script_introduction(GameObject baseObj, float[] duration, float fadeDurs) : base(true)
	{
		//only want to fade from 0-1
		float differenceAlpha = 1.0f;
		sceneObj = baseObj;
		eachImageDuration = duration;
		fadeDurations = fadeDurs;
		currentImageDuration = duration[currentImage];
		deltaAlpha = differenceAlpha / fadeDurs;
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
			//fade in picture
			if(sceneObj)
			{
				Transform child = sceneObj.transform.GetChild(currentImage);
				if(child)
				{
					UISprite spriteScript = child.GetComponent<UISprite>();
					if(spriteScript.alpha < 1.0f)
					{
						spriteScript.alpha += (deltaAlpha * Time.deltaTime);
					}

					currentImageDuration -= Time.deltaTime;
					if(currentImageDuration <= 0)
					{
						currentImage++;

						if(currentImage > 4)
						{
							Debug.Log("finished intro");
							base.cutScenePlaying = false;
							base.cutSceneFinished = true;
							currentImage = 4;
						}

						currentImageDuration = eachImageDuration[currentImage]; 
					}
				}
			}
		}
	}
}
