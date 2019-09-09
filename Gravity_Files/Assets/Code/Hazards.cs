using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazards : MonoBehaviour {

	public bool OneShotKill = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			if(OneShotKill){
				
				other.GetComponent<CubeMove> ().Respawn ();
			}
		//	other.GetComponent<CubeMove>()
			Debug.LogWarning ("You've been hit!");
			//	other.GetComponent<FOEHP> ().giveDamage (stomp);
			//myridgidbody.velocity = new Vector2 (myridgidbody.velocity.x, jumper);
		}

	}

}
