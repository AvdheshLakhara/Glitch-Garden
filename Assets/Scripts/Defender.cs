using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

	public int starCost = 100;

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/*void OnTriggerEnter2D()
	{
		Debug.Log (name + " is Triggered");
	}*/

	public void AddStars(int amount) 
	{
		starDisplay.AddStars (amount);
	}
}
