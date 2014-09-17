using UnityEngine;
using System.Collections;

public class SoundRandomLoopControl : MonoBehaviour {
	private float delayTimeToNextPlay;
	private bool hasRandomed = false;
	// Use this for initialization
	void Start () {
		delayTimeToNextPlay = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
		if(delayTimeToNextPlay < 0)
		{
			gameObject.audio.Play();
			delayTimeToNextPlay = Random.Range(6, 20);
		}
		else
		{
			delayTimeToNextPlay -= Time.deltaTime;
		}
	}
}
