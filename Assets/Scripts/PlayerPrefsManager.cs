using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume)
	{
		if (volume >= 0f && volume <= 1f)
		{
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("master volume out of range");
		}
	}

	public static float GetMasterVolume()
	{
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level)
	{
		if(level <= Application.levelCount - 1){
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // use 1 for true
		} else {
			Debug.LogError ("Trying to open non existing level");
		}
	}

	public static bool IsLevelUnlocked(int level)
	{
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);
		
		if(level <= Application.levelCount - 1){
			return isLevelUnlocked;
		} else {
			Debug.LogError ("Trying to query non existing level");
			return false;
		}
	}

	public static void SetDifficulty(float difficulty)
	{
		if(difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);	
		} else {
			Debug.LogError ("Out of range difficulty");
		}
	}

	public static float GetDifficulty()
	{
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}
}
