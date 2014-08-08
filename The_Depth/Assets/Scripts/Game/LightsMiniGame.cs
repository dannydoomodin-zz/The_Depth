using UnityEngine;
using System.Collections;

public class LightsMiniGame : MonoBehaviour {

	private GameObject[] sphereLights;
	private GameObject[] lights;
	private GameObject[] powerCells;
	const int NUM_OF_POWER_CELLS = 3;
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

		setLight(0);
	}
	
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
					
					if(hit.transform.gameObject.name == "powerCell1")
					{
						turnPowerCell(0);
					}
					else if(hit.transform.gameObject.name == "powerCell2")
					{
						turnPowerCell(1);
					}
					else if(hit.transform.gameObject.name == "powerCell3")
					{
						turnPowerCell(2);
					}
				}
			}
		}
	}

	bool checkFinished()
	{
	
		if(lights[0].activeSelf && lights[1].activeSelf && lights[2].activeSelf)
		{
			Debug.Log ("cells powered up.. engine is going");
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

	void setLight(int lightNum)
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
