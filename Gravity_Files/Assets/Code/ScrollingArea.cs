using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingArea : MonoBehaviour {

	private float PosY;
	private Vector3 RespawnPos;

	public bool IsScrolling;

//	private Vector3 RespawnPos = new Vector3(280,240,0);

	// Use this for initialization
	void Start () {

		RespawnPos = GetComponent<Transform> ().position;
		PosY = GetComponent<Transform> ().position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (IsScrolling) {
			PosY += 1;
			RespawnPos = new Vector3 (RespawnPos.x, PosY, 0);
			GetComponent<Transform> ().position = RespawnPos;
		}



	}
}
