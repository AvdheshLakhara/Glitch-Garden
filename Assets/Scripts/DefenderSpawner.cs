using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject parent;
	private StarDisplay starDisplay;

	void Start() {
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();

		if (!parent) {
			parent = new GameObject("Defenders");
		}
	}

	void OnMouseDown() 
	{		
		Vector2 rawPose = CalculateWorldPointOfMouseClick ();
		Vector2 roundedPose = SnapToGrid (rawPose);
		GameObject defender = Button.selectedDefender;

		int defenderCost = defender.GetComponent<Defender> ().starCost;
		if(starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
			SpawnDefender (roundedPose, defender);
		} else {
			Debug.Log ("Insufficient Stars");
		}
	}

	void SpawnDefender(Vector2 roundedPose, GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPose, zeroRot) as GameObject;

		newDef.transform.parent = parent.transform;
	}

	Vector2 CalculateWorldPointOfMouseClick ()
	{
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

		return worldPos;
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos)
	{
		float newX = Mathf.RoundToInt (rawWorldPos.x);
		float newY = Mathf.RoundToInt (rawWorldPos.y);

		return new Vector2 (newX, newY);
	}
}