using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public GameObject loadMenu;
	public GameObject mainMenu;
	public GameObject newGameMenu;

	IEnumerator StartNewGame ()
	{
		Debug.LogError("starting new game");
		DisableAllButtons(loadMenu);
		DisableAllButtons(mainMenu);
		DisableAllButtons(newGameMenu);

		//Play prologue -Start fade in
		TransitionManager.instance.Fade(1.0f, 2.0);
		while(!TransitionManager.instance.finishedFading)
		{
			yield return new WaitForSeconds(1);
		}
		SceneManager.instance.DisplayScene(SceneManager.Scenes.prologue);
		SceneManager.instance.PlayCurrentScene();
		HideMainMenu();
		while(!SceneManager.instance.isSceneFinished)
		{
			yield return new WaitForSeconds(1);
		}

		//Load intro cutscene
		SceneManager.instance.HideAllScene(SceneManager.Scenes.intro_cutscene);
		SceneManager.instance.DisplayScene(SceneManager.Scenes.intro_cutscene);
		TransitionManager.instance.Fade(0.0f, 5.0);

		while(!TransitionManager.instance.finishedFading)
		{
			yield return new WaitForSeconds(1);
		}
		Debug.Log ("playing intro");
		SceneManager.instance.PlayCurrentScene();

		while(!SceneManager.instance.isSceneFinished)
		{
			yield return new WaitForSeconds(1);
		}

		//fade to black then start game
		TransitionManager.instance.Fade(1.0f, 2.0);
		while(!TransitionManager.instance.finishedFading)
		{
			yield return new WaitForSeconds(1);
		}

		//wait for a little while before loading
		yield return new WaitForSeconds(2);

		Application.LoadLevel("game");
	}

	void LoadSave(int saveNumber)
	{
		Debug.LogError("loading save game " + saveNumber);
		PlayerProfile.instance.Load(saveNumber);
	}

	void StartNewSave(int saveNumber)
	{
		Debug.LogError("saving at slot " + saveNumber);
		PlayerProfile.instance.Save(saveNumber);
		StartCoroutine( StartNewGame());
	}
	
	void ShowMainMenu()
	{
		Debug.LogError("showing main menu");

		Transform loadBtn = mainMenu.transform.FindChild("LoadButton");

		if(!PlayerProfile.instance.Save1Avaliable() && 
		   !PlayerProfile.instance.Save2Avaliable() && 
		   !PlayerProfile.instance.Save3Avaliable())
		{
			if(loadBtn)
			{
				loadBtn.GetComponent<Collider>().enabled = false;
			}
		}
		else
		{	
			if(loadBtn)
			{
				loadBtn.GetComponent<Collider>().enabled = true;
			}
		}

		Util.setObjectActive(mainMenu);
		loadMenu.SetActive(false);
		newGameMenu.SetActive(false);
	}

	void ShowLoadMenu ()
	{
		Debug.LogError("showing load menu");

		Transform save1Btn = loadMenu.transform.FindChild("Save1Button");
		Transform save2Btn = loadMenu.transform.FindChild("Save2Button");
		Transform save3Btn = loadMenu.transform.FindChild("Save3Button");

		if(!PlayerProfile.instance.Save1Avaliable())
		{
			if(save1Btn)
			{
				save1Btn.GetComponent<Collider>().enabled = false;
			}
		}
		else
		{
			if(save1Btn)
			{
				save1Btn.GetComponent<Collider>().enabled = true;
			}
		}
		
		if(!PlayerProfile.instance.Save2Avaliable())
		{
			if(save2Btn)
			{
				save2Btn.GetComponent<Collider>().enabled = false;
			}
		} 
		else
		{
			if(save2Btn)
			{
				save2Btn.GetComponent<Collider>().enabled = true;
			}
		}
		
		if(!PlayerProfile.instance.Save3Avaliable())
		{
			if(save3Btn)
			{
				save3Btn.GetComponent<Collider>().enabled = false;
			}
		}
		else
		{
			if(save3Btn)
			{
				save3Btn.GetComponent<Collider>().enabled = true;
			}
		}

		Util.setObjectActive(loadMenu);
		mainMenu.SetActive(false);
		newGameMenu.SetActive(false);
	}

	void ShowNewGameMenu ()
	{
		Debug.LogError("showing new game menu");

		Util.setObjectActive(newGameMenu);
		mainMenu.SetActive(false);
		loadMenu.SetActive(false);
	}

	void DisableAllButtons(GameObject obj)
	{
		int buttonCount = obj.transform.childCount;
		for(int count = 0; count < buttonCount; count++)
		{
			Collider c = obj.transform.GetChild(count).GetComponent<Collider>();
			if(c)
			{
				c.enabled = false;
			}
		}
	}

	void HideMainMenu()
	{
		newGameMenu.SetActive(false);
		mainMenu.SetActive(false);
		loadMenu.SetActive(false);
		GameObject mainTitle = GameObject.Find("MainTitleTxt");
		if(mainTitle)
		{
			mainTitle.SetActive(false);
		}
	}

	void Awake()
	{
		//Debugging
		PlayerProfile.instance.ResetGame();

		if(!PlayerProfile.instance.Save1Avaliable() && 
		   !PlayerProfile.instance.Save2Avaliable() && 
		   !PlayerProfile.instance.Save3Avaliable())
		{
			Transform loadBtn = mainMenu.transform.FindChild("LoadButton");
			
			if(loadBtn)
			{
				loadBtn.GetComponent<Collider>().enabled = false;
			}
		}
	}
}
