using UnityEngine;
using System.Collections;

public class PlayerPrefExt{

	/*	Have to make redundant methods for getInt, setInt etc. cus playerpref class is sealed.
	*	This implementation of player prefs throws an ArgumentException when Get methods does not find a key
	*/
	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}

	public static void DeleteKey(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	public static float GetFloat(string key)
	{
		if(!PlayerPrefs.HasKey(key))
		{
			throw new System.ArgumentException();
		}

		return PlayerPrefs.GetFloat(key);
	}

	public static int GetInt(string key)
	{
		if(!PlayerPrefs.HasKey(key))
		{
			throw new System.ArgumentException();
		}

		return PlayerPrefs.GetInt(key);
	}

	public static string GetString(string key)
	{
		if(!PlayerPrefs.HasKey(key))
		{
			throw new System.ArgumentException();
		}

		return PlayerPrefs.GetString(key);
	}

	public static bool HasKey(string key)
	{
		return PlayerPrefs.HasKey(key);
	}

	public static void Save()
	{
		PlayerPrefs.Save();
	}

	public static void SetFloat(string key, float value)
	{
		PlayerPrefs.SetFloat(key, value);
	}

	public static void SetInt(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public static void SetString(string key, string value)
	{
		PlayerPrefs.SetString(key, value);
	}

	public static void SetBool(string key, bool value) 
	{
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}
		
	// newly implemented get and set bool
	public static bool GetBool(string key)  
	{
		if(!PlayerPrefs.HasKey(key))
		{
			throw new System.ArgumentException();
		}

		return PlayerPrefs.GetInt(key) == 1 ? true : false;
	}
}
