using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearences")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget;
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget){
			anim.SetBool ("isAttacking", false);
		}
	}

	/*void OnTriggerEnter2D()
	{
		Debug.Log (name + " is Triggered");
	}*/

	public void SetSpeed(float speed)
	{
		currentSpeed = speed;
	}

	// Called form the animator at time of actual blow

	public void StrikeCurrentTarget(float damage)
	{
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health> ();
			if(health){
				health.DealDamage (damage);
			}
		}
	}

	/*public void StrikeCurrentTarget(float damage)
	{
		Debug.Log (name + " caused damage: " + damage);
	}*/

	public void Attack(GameObject obj)
	{
		currentTarget = obj;
	}

}
