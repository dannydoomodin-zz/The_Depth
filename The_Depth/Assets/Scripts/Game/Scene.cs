using UnityEngine;
using System.Collections;

public class Scene {

	private bool isCutScene = false;

	protected bool cutScenePlaying = false;

	protected bool cutSceneFinished = false;

	protected GameObject sceneObj = null;

	public bool isCutScenePlaying
	{
		get
		{
			return cutScenePlaying;
		}
	}

	public bool isCutSceneFinished
	{
		get
		{
			return cutSceneFinished;
		}
	}

	public Scene(bool cutScene)
	{
		isCutScene = cutScene;
	}

	public virtual void Init()
	{

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}

	public virtual void show()
	{
		Util.setObjectActive(sceneObj);
	}

	public virtual void hide()
	{
		sceneObj.SetActive(false);
	}
}
