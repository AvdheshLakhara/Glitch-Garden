using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter;

	void Start()
	{
		if(autoLoadNextLevelAfter <= 0){
			Debug.LogWarning ("Level auto load disabled, use a positive number in seconds");
		} else {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		} /*else {
			CancelInvoke ("LoadNextLevel");
		}*/
	}

	public void LoadLevel(string name){
		Debug.Log ("New Level Load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit Requested");
		Application.Quit ();
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
	}

}
