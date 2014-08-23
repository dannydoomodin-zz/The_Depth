using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {

	private static SceneManager s_Instance = null;

	private Scenes currentScene = Scenes.noScene;

	public GameObject[] sceneObjs;

	private Scene[] sceneScripts;

	private bool finishedLoading = false;

	//for cutscene to see if cutscene has finished playing
	public bool isSceneFinished
	{
		get
		{
			return sceneScripts[(int)currentScene].isCutSceneFinished;
		}
	}

	public bool isCutScenePlaying
	{
		get
		{
			return sceneScripts[(int)currentScene].isCutScenePlaying;
		}
	}

	public bool isFinishLoading
	{
		get
		{
			return finishedLoading;
		}
	}

	public enum SceneType
	{
		prologue,
		intro_cutscene,
		rooms
	}

	public enum Scenes
	{
		prologue,
		intro_cutscene,
		Cell,
		Corrordor,
		Airlock,
		CrewQuarter,
		DivingRoom,
		EngineRoom,
		Store,
		CommandCentre,
		Galley,
		DiningRoom,
		Library,
		Salon,
		NRoom,
		noScene
	}

	public Scenes GetSceneEnumByName(string name)
	{
		if(name == Scenes.prologue.ToString())
		{
			return Scenes.prologue;
		}
		else if(name == Scenes.intro_cutscene.ToString())
		{
			return Scenes.intro_cutscene;
		}
		else if(name == Scenes.Cell.ToString())
		{
			return Scenes.Cell;
		}
		else if(name == Scenes.Corrordor.ToString())
		{
			return Scenes.Corrordor;
		}
		else if(name == Scenes.Airlock.ToString())
		{
			return Scenes.Airlock;
		}
		else if(name == Scenes.CrewQuarter.ToString())
		{
			return Scenes.CrewQuarter;
		}
		else if(name == Scenes.DivingRoom.ToString())
		{
			return Scenes.DivingRoom;
		}
		else if(name == Scenes.EngineRoom.ToString())
		{
			return Scenes.EngineRoom;
		}
		else if(name == Scenes.Store.ToString())
		{
			return Scenes.Store;
		}
		else if(name == Scenes.Galley.ToString())
		{
			return Scenes.Galley;
		}
		else if(name == Scenes.DiningRoom.ToString())
		{
			return Scenes.DiningRoom;
		}
		else if(name == Scenes.Library.ToString())
		{
			return Scenes.Library;
		}
		else if(name == Scenes.Salon.ToString())
		{
			return Scenes.Salon;
		}
		else if(name == Scenes.NRoom.ToString())
		{
			return Scenes.NRoom;
		}
		else if(name == Scenes.CommandCentre.ToString())
		{
			return Scenes.CommandCentre;
		}
		else
		{
			return Scenes.noScene;
		}
	}

	void Awake()
	{
		sceneScripts = new Scene[3];
		sceneScripts[0] = new script_prologue(sceneObjs[(int)Scenes.prologue], Constants.scrollTextDuration, Constants.scrollTextAnchorEnd, Constants.prologueFadeOutDuration, Constants.imageFadeInDuration);
		sceneScripts[1] = new script_introduction(sceneObjs[(int)Scenes.intro_cutscene], Constants.introImageDuration, Constants.introFadeDuration);
	}

	void OnLevelWasLoaded (int level) {
		if (level == 1) {
			Debug.Log ("Initilising rooms");
			sceneObjs[(int)Scenes.Cell] = GameObject.Find(Scenes.Cell.ToString());
			sceneObjs[(int)Scenes.Corrordor] = GameObject.Find(Scenes.Corrordor.ToString());
			sceneObjs[(int)Scenes.Airlock] = GameObject.Find(Scenes.Airlock.ToString());
			sceneObjs[(int)Scenes.CrewQuarter] = GameObject.Find(Scenes.CrewQuarter.ToString());
			sceneObjs[(int)Scenes.DivingRoom] = GameObject.Find(Scenes.DivingRoom.ToString());
			sceneObjs[(int)Scenes.Store] = GameObject.Find(Scenes.Store.ToString());
			sceneObjs[(int)Scenes.EngineRoom] = GameObject.Find(Scenes.EngineRoom.ToString());
			sceneObjs[(int)Scenes.CommandCentre] = GameObject.Find(Scenes.CommandCentre.ToString());

			//Hide all room except the cell room
			HideAllScene(Scenes.Cell);
			DisplayScene(Scenes.Cell);

			//level preparation finished show scene
			TransitionManager.instance.Fade(0.0f, 5.0);
		}
	}


	public static SceneManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				SceneManager tmpInst = FindObjectOfType(typeof(SceneManager)) as SceneManager;
				if (tmpInst != null)
					tmpInst.Awake();
				s_Instance = tmpInst;
				
				if (s_Instance == null && Application.isEditor)
					Debug.LogError("Could not locate a object. You have to have exactly one object in the scene.");
			}
			
			return s_Instance;
		}
	}

	public Scenes GetCurrentScene()
	{
		return currentScene;
	}

	public void DisplayScene(Scenes scene)
	{
		finishedLoading = false;
		currentScene = scene;
		sceneObjs[(int)currentScene].SetActive(true);
		//Util.setObjectActive(sceneObjs[(int)currentScene]);
		finishedLoading = true;
	}

	public void PlayCurrentScene()
	{
		if(currentScene == Scenes.intro_cutscene || currentScene == Scenes.prologue)
		{
			sceneScripts[(int)currentScene].Init();
		}
	}

	public void HideAllScene(Scenes exception)
	{
		for(int count = 0; count < sceneObjs.Length; count++)
		{
			if(count != (int)exception && sceneObjs[count])
			{
				sceneObjs[count].SetActive(false);
			}
		}
	}

	void Update()
	{
		if(currentScene == Scenes.prologue || currentScene == Scenes.intro_cutscene)
		{
			sceneScripts[(int)currentScene].Update();
		}
	}
}
