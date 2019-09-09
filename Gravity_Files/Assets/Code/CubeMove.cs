using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeMove : MonoBehaviour {
	
	private bool grounded=true;

	//Movement, weapon and health varibles
	private float moveVelocity;
	public float moveS;
	private float WeaponDelay;
	public float PlayerHealth;
	private float movex;
	private float movey;

	// Knockback varibles
	public float knockback;
	public float KBpush;
	public float KBduration;
	public GameObject SpriteSelf;

	public bool IsKill;
//	private bool fish;

	private Vector3 RespawnPos = new Vector3(280,240,0);
	//private PlayerMoveV2 player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// maybe have no gravity and have everything else move up instead

		moveVelocity = 0f	;	//
		if (!IsKill) {
			movex = Input.GetAxis ("Horizontal");
			movey = Input.GetAxis ("Vertical");
			 
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (movex * moveS, GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, movey * moveS);
		} else {
			movex = 0;
			movey = 0;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,0);
		}
	}

	public void Damaged()
	{

	}

	public void Respawn()
	{
		GetComponent<Image> ().color = new Color (230,0,255,1);
		IsKill = true;
		StartCoroutine (Delay(1f));

	}

	IEnumerator Delay(float WDelay )
	{
		yield return new WaitForSeconds(WDelay);
		GetComponent<Image> ().color = new Color (255,255,255,1);
		GetComponent<Transform> ().position = RespawnPos;
		IsKill = false;
	//	CanAttack = true;
		//Moving = false;
	}



	/*
	IEnumerator  FlashingRed(){

		// Probably won't work unless connected to update
		while (toGreen) {
			// fade color to green
			if (lerpValue < 1) { 

				lerpValue += Time.deltaTime / lerpDuration;
				gameObject.GetComponent<Image> ().color = Color.Lerp (Color.red, Color.green, lerpValue);
			} else {
				toGreen = false;
				lerpValue = 0f;
			}
		}
	}
*/
}
