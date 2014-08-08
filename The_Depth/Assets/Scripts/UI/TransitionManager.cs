using UnityEngine;
using System.Collections;

public class TransitionManager : MonoBehaviour {

	private static TransitionManager s_Instance = null;

	private const int numberOfTransitions = 2;
	private GameObject fadeSprite;
	
	private float deltaAlpha;
	private bool isFadeIn;
	private float requiredAlpha;
	private float endTime;
	private bool isFinishedFading;

	public static TransitionManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				TransitionManager tmpInst = FindObjectOfType(typeof(TransitionManager)) as TransitionManager;
				if (tmpInst != null)
					tmpInst.Awake();
				s_Instance = tmpInst;
				
				if (s_Instance == null && Application.isEditor)
					Debug.LogError("Could not locate a object. You have to have exactly one object in the scene.");
			}

			return s_Instance;
		}
	}

	public bool finishedFading
	{
		get
		{
			return isFinishedFading;
		}
	}

	void Awake()
	{
		deltaAlpha = 0.0f;
		requiredAlpha = 0.0f;
		isFadeIn = false;
		isFinishedFading = true;
	}
	public enum Transitions
	{
		woodenDoor,
		metalDoor
	}

	public void PlayAnimation (Transitions transition) {}
	
	public void HideAnimation (Transitions transition) {}

	//percentage 0-1
	public void Fade(float fadeToPercentage, double seconds)
	{
		if(!fadeSprite)
		{
			fadeSprite = GameObject.Find("FaderSprite");
		}

		isFinishedFading = false;
		UISprite spriteScript = fadeSprite.transform.GetComponent<UISprite>();
		float originalAlpha = spriteScript.color.a;
		requiredAlpha = fadeToPercentage;
		deltaAlpha = (requiredAlpha - originalAlpha)/(float)seconds;
		endTime = Time.time + (float)seconds;

		if( originalAlpha > requiredAlpha)
		{
			isFadeIn = false;
		}
		else
		{
			isFadeIn = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(fadeSprite)
		{
			UISprite spriteScript = fadeSprite.transform.GetComponent<UISprite>();

			if(Time.time <= endTime)
			{
				if(isFadeIn)
				{
					if(spriteScript.color.a <= requiredAlpha)
					{
						Color newColor = new Color(spriteScript.color.r, 
						                           spriteScript.color.g, 
						                           spriteScript.color.b, 
						                           spriteScript.color.a + ((float)deltaAlpha * Time.deltaTime));
						
						spriteScript.color = newColor;
					}
				}
				else
				{
					if(spriteScript.color.a >= requiredAlpha)
					{
						Color newColor = new Color(spriteScript.color.r, 
						                           spriteScript.color.g, 
						                           spriteScript.color.b, 
						                           spriteScript.color.a + ((float)deltaAlpha * Time.deltaTime));
						
						spriteScript.color = newColor;
					}
				}
			}
			else
			{
				isFinishedFading = true;

			}
		}
	}
}
