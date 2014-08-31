using UnityEngine;
using System.Collections;

public class LightsMiniGame : MonoBehaviour {

	private GameObject[] sphereLights;
	private GameObject[] lights;
	private GameObject[] powerCells;
	const int NUM_OF_POWER_CELLS = 3;
	public bool canPlayLightsMiniGame = false;
	private bool startedEngine = false;
	public GameObject[] OilTankAudios;

	// Use this for initialization
	void Start () {
		lights = new GameObject[NUM_OF_POWER_CELLS];
		powerCells = new GameObject[NUM_OF_POWER_CELLS];
		sphereLights = new GameObject[NUM_OF_POWER_CELLS];

		for(int x = 0; x < NUM_OF_POWER_CELLS; x++)
		{
			powerCells[x] = transform.FindChild("powerCell"+(x+1)).gameObject;
			sphereLights[x] = transform.FindChild("Sphere"+(x+1)).gameObject;
			lights[x] = transform.FindChild("miniGame_light"+(x+1)).gameObject;
			lights[x].SetActive(false);
		}
	}

/*	void OnAwake()
	{
		var audio1 = OilTankAudios[0].transform.parent.audio;
		var audio2 = OilTankAudios[1].transform.parent.audio;
		if(!audio1.isPlaying)
		{
			audio1.pla
		}

		if(!audio2.isPlaying)
		{
			
		}
	}*/
	
	// Update is called once per frame
	void Update () {
		if(!checkFinished())
		{
			if(Input.GetMouseButtonUp(0))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				
				if(Physics.Raycast(ray, out hit, 100))
				{
					Debug.Log(hit.transform.gameObject.name);
					
					if(hit.transform.gameObject.name == "powerCell1" && canPlayLightsMiniGame)
					{
						turnPowerCell(0);
					}
					else if(hit.transform.gameObject.name == "powerCell2" && canPlayLightsMiniGame)
					{
						turnPowerCell(1);
					}
					else if(hit.transform.gameObject.name == "powerCell3" && canPlayLightsMiniGame)
					{
						turnPowerCell(2);
					}
					else if((hit.transform.gameObject.name == "powerCell1" ||  
					         hit.transform.gameObject.name == "powerCell2" ||
					         hit.transform.gameObject.name == "powerCell3" ) && !canPlayLightsMiniGame)
					{
						ArrayList list = new ArrayList();
						list.Add("This should be the startup sequence for the engine, but it's not working...");
						list.Add("Maybe there is something wrong with the engine?");
						Util.setDialogue(list);
					}
				}
			}
		}
	}

	bool checkFinished()
	{
		if(startedEngine)
		{
			return true;
		}
	
		if(lights[0].activeSelf && lights[1].activeSelf && lights[2].activeSelf)
		{
			startedEngine = true;
			Debug.Log ("cells powered up.. engine is going");
		
			OilTankAudios[0].audio.audio.PlayDelayed(1.5f);
			OilTankAudios[1].audio.Play();

			OilTankAudios[0].transform.parent.audio.PlayDelayed(31.5f);
			OilTankAudios[1].transform.parent.audio.PlayDelayed(30.0f);

			OilTankAudios[0].transform.parent.audio.playOnAwake = true;
			OilTankAudios[1].transform.parent.audio.playOnAwake = true;
			return true;
		}

		return false;
	}

	void turnPowerCell(int cellNum)
	{
		switch(cellNum)
		{
		case 0:
			setLight(0);
			setLight(1);
			break;
		case 1:
			setLight(0);
			setLight(2);
			break;
		case 2:
			setLight(0);
			setLight(1);
			setLight(2);
			break;
		}
	}

	public void setLight(int lightNum)
	{
		if(lights[lightNum].activeSelf)
		{
			turnOff(lightNum);
		}
		else
		{
			turnOn(lightNum);
		}
	}

	void turnOn(int cellNum)
	{
		Material offLight = Resources.LoadAssetAtPath("Assets/Resources/Materials/Light_on.mat", typeof(Material)) as Material;
		sphereLights[cellNum].renderer.material = offLight;

		lights[cellNum].SetActive(true);
	}

	void turnOff(int cellNum)
	{
		Material onLight = Resources.LoadAssetAtPath("Assets/Resources/Materials/Light_off.mat", typeof(Material)) as Material;
		sphereLights[cellNum].renderer.material = onLight;
		
		lights[cellNum].SetActive(false);
	}
}
