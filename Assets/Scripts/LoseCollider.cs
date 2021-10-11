using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	//private GameObject gameTimer;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		//gameTimer = GameObject.FindObjectOfType<GameTimer> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//Destroy (collision.gameObject);
		levelManager.LoadLevel ("03b Lose");
	}

}
