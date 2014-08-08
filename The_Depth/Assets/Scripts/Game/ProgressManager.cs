using UnityEngine;
using System.Collections;

public class ProgressManager : MonoBehaviour {

	private static ProgressManager s_Instance = null;

	private bool[] puzzlesCompleted;

	private const int numberOfPuzzles = 10;

	public enum puzzles
	{
		puzzle1,
		puzzle2,
		puzzle3,
		puzzle4,
		puzzle5,
		puzzle6,
		puzzle7,
		puzzle8,
		puzzle9,
		puzzle10
	}

	public static ProgressManager instance
	{
		get
		{
			if (s_Instance == null)
			{
				ProgressManager tmpInst = FindObjectOfType(typeof(ProgressManager)) as ProgressManager;
				if (tmpInst != null)
					tmpInst.Start();
				s_Instance = tmpInst;
				
				if (s_Instance == null && Application.isEditor)
					Debug.LogError("Could not locate a object. You have to have exactly one object in the scene.");
			}
			
			return s_Instance;
		}
	}

	public int GetNumberOfItems()
	{
		return numberOfPuzzles;
	}

	public bool IsComplete (int puzzle)
	{
		return puzzlesCompleted[(int)puzzle];
	}

	public void Complete (puzzles puzzle)
	{
		puzzlesCompleted[(int)puzzle] = true;
	}

	// Use this for initialization
	void Start () {
		puzzlesCompleted = new bool[numberOfPuzzles];

		for( int count = 0; count < numberOfPuzzles; count++)
		{
			puzzlesCompleted[count] = false;
		}
	}
}
