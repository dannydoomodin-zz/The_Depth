using UnityEngine;
using System.Collections;

public class PlayerProfile : MonoBehaviour {

	private static PlayerProfile s_Instance = null;

	public int stamina;
	public int health;
	private InventoryManager inventoryMan;
	private SceneManager sceneMan;
	private ProgressManager progressMan;
	public int saveSlot;
	
	public static PlayerProfile instance
	{
		get
		{
			if (s_Instance == null)
			{
				PlayerProfile tmpInst = FindObjectOfType(typeof(PlayerProfile)) as PlayerProfile;
				if (tmpInst != null)
					tmpInst.Start();
				s_Instance = tmpInst;
				
				if (s_Instance == null && Application.isEditor)
					Debug.LogError("Could not locate a object. You have to have exactly one object in the scene.");
			}
			
			return s_Instance;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		stamina = 100;
		health = 100;
		inventoryMan = InventoryManager.instance;
		sceneMan = SceneManager.instance;
		progressMan = ProgressManager.instance;
		saveSlot = 1;
	}

	public void ResetGame()
	{
		PlayerPrefExt.DeleteAll();
	}

	/*game auto saves
	 *list of info game saves:
	 *Current health
	 *Current stamina
	 *List of found items
	 *Current room
	 *List of solved puzzles
	*/
	public bool Save(int saveNumber)
	{
		try{
			int count = 0 ;

			string s = "save avaliable-" + saveNumber;
			PlayerPrefExt.SetBool(s, true); 

			//save current health
			s = "current health-" + saveNumber;
			PlayerPrefExt.SetInt(s, health);

			//save current stamina
			s = "current stamina-" + saveNumber;
			PlayerPrefExt.SetInt(s, stamina);

			//save curent inventory
			string itemList = "";
			for(count = 0; count < inventoryMan.GetNumberOfItems(); count++)
			{
				if(count == 0)
				{
					itemList = itemList + inventoryMan.getItemName(0);
				}
				itemList = itemList + "," + inventoryMan.getItemName(count);
			}

			s = "items-" + saveNumber;
			PlayerPrefExt.SetString(s, itemList);

			//save current room
			s = "curret scene-" + saveNumber;
			PlayerPrefExt.SetInt(s, (int)sceneMan.GetCurrentScene()); 

			//save puzzle progress
			for(count = 0; count < progressMan.GetNumberOfItems(); count++)
			{
				s = "puzzle" + count + "-" + saveNumber;
				bool isComplete = progressMan.IsComplete(count);
				PlayerPrefExt.SetBool(s, isComplete);
			}

			//flag that particular save is avaliable
			s = "save avaliable-" + saveNumber;
			PlayerPrefExt.SetBool(s, true);

			PlayerPrefExt.Save();
			return true;
		}
		catch
		{
			Debug.LogError("error in saving profile may not have been saved");
			return false;
		}
	}

	public bool Load(int saveNumber)
	{
		int value = 0;
		string stringValue = "";
		try
		{
			int count = 0 ;
			
			//load current health
			string s = "current health-" + saveNumber;
			health = PlayerPrefExt.GetInt(s);
			
			//load current stamina
			s = "current stamina-" + saveNumber;
			stamina = PlayerPrefExt.GetInt(s);
			
			//load curent inventory
			s = "items-" + saveNumber;
			string itemList = PlayerPrefExt.GetString(s);
			if(itemList != "")
			{
				string[] items = itemList.Split(',');
				foreach(string item in items)
				{
					string[] itemComponents = item.Split('_');
					string id = itemComponents[0];
					string room = itemComponents[1];
					inventoryMan.AddItemByName(room, id);
				}
			}

			//load current room
			s = "curret scene-" + saveNumber;
			int scene = PlayerPrefExt.GetInt(s); 
			sceneMan.DisplayScene((SceneManager.Scenes)scene);
			
			//load puzzle progress
			for(count = 0; count < progressMan.GetNumberOfItems(); count++)
			{
				s = "puzzle" + count + "-" + saveNumber;
				bool isComplete = PlayerPrefExt.GetBool(s);
				if(isComplete)
				{
					progressMan.Complete((ProgressManager.puzzles)count);
				}
			}

			return true;
		}
		catch
		{
			Debug.LogError("cannot load corrupted save: " + saveNumber);
			return false;
		}
	}

	public int GetCurrentStamina ()
	{
		return stamina;
	}

	public int GetCurrentHealth ()
	{
		return health;
	}

	public void AddStamina (int amount)
	{
		stamina += amount;
		if(stamina > 100)
		{
			stamina = 100;
		}
		updatePlayerHealthStamina();
	}

	public void AddHealth (int amount)
	{
		health =+ amount;
		if(health > 100)
		{
			health = 100;
		}
		updatePlayerHealthStamina();
	}

	public void RemoveStamina (int amount)
	{
		stamina =- amount;
		updatePlayerHealthStamina();
	}
	
	public void RemoveHealth (int amount)
	{
		health -= amount;
		updatePlayerHealthStamina();
	}

	void updatePlayerHealthStamina()
	{
		GameObject.Find("CurrentHealth").GetComponent<UILabel>().text = "" + health;
		GameObject.Find("CurrentStamina").GetComponent<UILabel>().text = "" + stamina;

	}

	public bool Save1Avaliable()
	{
		string s = "save avaliable-1";
		//check if there are any saves
		try
		{
			if(!PlayerPrefExt.GetBool(s))
			{
				return false;
			}

			return true;
		}
		catch
		{
			Debug.LogError("curropted profile, assuming no saves avaliable");
			return false;
		}
	}

	public bool Save2Avaliable()
	{
		try
		{
			string s = "save avaliable-2";
			//check if there are any saves
			if(!PlayerPrefExt.GetBool(s))
			{
				return false;
			}

			return true;
		}
		catch
		{
			Debug.LogError("curropted profile, assuming no saves avaliable");
			return false;
		}
	}

	public bool Save3Avaliable()
	{
		try
		{
			string s = "save avaliable-3";
			//check if there are any saves
			if(!PlayerPrefExt.GetBool(s))
			{
				return false;
			}

			return true;
		}
		catch
		{
			Debug.LogError("curropted profile, assuming no saves avaliable");
			return false;
		}
	}
}
