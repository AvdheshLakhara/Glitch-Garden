using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	public float levelSeconds;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private LevelManager levelManager;
	private GameObject winLabel;
	private GameObject loseCollider;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		loseCollider = GameObject.Find("LoseCollider");
		YouWin ();
		winLabel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;

		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if(timeIsUp && !isEndOfLevel){
			audioSource.Play ();
			loseCollider.SetActive (false);
			winLabel.SetActive (true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
		}
	}

	void YouWin()
	{
		winLabel = GameObject.Find ("You Win");	
		if(!winLabel){
			Debug.LogWarning ("Please create You Win object");
		}
		//loseCollider.SetActive (false);
	}

	void LoadNextLevel()
	{
		levelManager.LoadNextLevel ();
	}
}
