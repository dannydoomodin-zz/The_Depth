using UnityEngine;
using System.Collections;

public class Constants {
	public enum clickableScenes
	{
		toilet,
		sink,
		crate1,
	}

	public static float[] camHeight = 
	{
		0.7f,
		0.4f,
		0.0f,
	};

	public static float scrollTextDuration = 50.0f;
	public static float scrollTextAnchorEnd = 2.24f;
	public static float prologueFadeOutDuration = 5.0f;
	public static float imageFadeInDuration = 2.0f;

	public static float introFadeDuration = 2.0f;

	public static float[] introImageDuration = {5.0f, 5.0f, 10.0f, 5.0f, 10.0f, 5.0f};

	public static float skipIntroDelay = 5.0f;

	public static int DebugRoomUpperLimit = 8;

	public static int DebugRoomLowerLimit = 2;
}
