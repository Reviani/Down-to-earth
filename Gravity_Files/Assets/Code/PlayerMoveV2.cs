using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMoveV2 : MonoBehaviour {

    // Bools that check various things
	private bool grounded=true;
	private bool CanAttack;
	public bool totheright=false;
    
    //What kind of weapon is held
	public int WeaponNum;
    
    //Movement, weapon and health varibles
	private float moveVelocity;
	public float jumpu;
	public float moveS;
	private float WeaponDelay;
	public float PlayerHealth;
	private float movex;
    
    // Knockback varibles
    public float knockback;
	public float KBpush;
	public float KBduration;
	public GameObject SpriteSelf;
    
    //Make varibles for invincablility frames
    
	//Animation varibles
	public Animator NewAnimations;
	//public GameObject Spear;
//	private PlayerSoundEffectManager SoundsManager;

	

	// Use this for initialization
	void Start () {
		//anim = Spear.GetComponent<Animator> ();


		NewAnimations = GetComponent<Animator> ();
		//SoundsManager = GetComponent<PlayerSoundEffectManager> ();
		WeaponNum = 2;
		CanAttack = true;


		SpriteSelf = GameObject.Find ("Test");
	//	SpriteSelf.GetComponent<Image> ().color = new Color (SpriteSelf.GetComponent<Image> ().color.r , SpriteSelf.GetComponent<Image> ().color.g, SpriteSelf.GetComponent<Image> ().color.b, 0.4f);


	}



	// Update is called once per frame
	void Update () {

		if (grounded == true) {
			//MidAir
			NewAnimations.SetBool ("MidAir", false);
		} else {
			NewAnimations.SetBool ("MidAir", true);
		}
				

		moveVelocity = 0f	;	//
		if (true) {
			movex = Input.GetAxis ("Horizontal");
		}
			


		if (KBpush <= 0) {// Enemy knockback
			if (CanAttack || !grounded)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (movex * moveS, GetComponent<Rigidbody2D> ().velocity.y);
			else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (movex * moveS / 2, GetComponent<Rigidbody2D> ().velocity.y);
			}
		}
		else{ 
			if(totheright)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-knockback,( knockback/2));
			else
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (knockback, ( knockback/2));
			KBpush -= Time.deltaTime;

		}


		if (Input.GetButtonDown("Jump")&& grounded) //Jump check
		{
			Jump();
		}
				
		if (CanAttack) {  // Attack direction Manager
			if (movex < 0) {
				totheright = false;
				transform.localRotation = Quaternion.Euler (0, 180, 0);
			} else {
				if (movex > 0) {
					totheright = true;
					transform.localRotation = Quaternion.Euler (0, 0, 0);
				}
			}
		}

		//Mine animation
		if (NewAnimations.GetBool ("Mine")) {
		}
			//NewAnimations.SetBool ("Mine", false);

		// resets animation after doing them
		if (NewAnimations.GetInteger ("Weapon") != -1) {
		}
		//NewAnimations.SetInteger ("Weapon", -1);

		//Switch weapons, for now
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			
			switch (WeaponNum) {
			case 1:
				WeaponNum = 2;
				break;

			case 2:
				WeaponNum = 1;
				break;
			}
		}

		// Mine Hit and things
		if (CanAttack) {
			if (Input.GetKeyDown (KeyCode.C)) {// Mineing
		//		SoundsManager.PlaySoundEffect (1);
				NewAnimations.SetBool ("Mine", true);
				NewAnimations.SetBool ("Attacking",true);
				CanAttack = false;
				StartCoroutine (Delay (0.6f));
				//NewAnimations.SetBool ("Mine", false);
				//WeaponNum = hold;

			}
		}
		 
	
		if (Input.GetButtonDown ("Fire2")) {// Stabby
			if (CanAttack) {
				GetWeapon ();
			}
			//Debug.Log ("Thing");
			//Spear.SetActive(true);
			//anim.GetComponent<Animation>().Play ();
		}
	
	// hcdcAa*39
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Ground" || other.tag == "Block" || other.tag == "CloverBlock") {
			grounded = true;
		}

			if (other.name == "Pit") {
			Debug.Log ("HitPit");
			Debug.Log (other.transform.position.y);
				//grounded = true;
		}

	}
    
	void OnTriggerExit2D(Collider2D other)
	{
		
		if (other.tag == "Ground"||other.tag == "Block"||other.tag == "CloverBlock" ) {
			grounded = false;
		}

	}

	public void Jump()
	{
//		SoundsManager.PlaySoundEffect (4);
		GetComponent<Rigidbody2D>().velocity= new Vector2(0,jumpu);
	}

	public void GetWeapon()
	{

		switch (WeaponNum) {
		case 1:
			//anim.SetBool ("Spear", true);
	//		SoundsManager.PlaySoundEffect (1);
			NewAnimations.SetInteger ("Weapon", 1);
			NewAnimations.SetBool ("Attacking",true);
			CanAttack = false;
			StartCoroutine (Delay(0.3f));
			break;
		case 2:
			//anim.SetBool ("Sword", true);
		//	SoundsManager.PlaySoundEffect (2);
			NewAnimations.SetInteger("Weapon",2);
			NewAnimations.SetBool ("Attacking",true);
			CanAttack = false;
		//	yield return waitfo
			StartCoroutine (Delay(.7f));
			break;
		case 3:
			//anim.SetBool ("Null", true);
			NewAnimations.SetInteger("Weapon",3);
			CanAttack = false;
			StartCoroutine (Delay(0.4f));
			break;


		}
	}

	IEnumerator Delay(float WDelay )
	{
		yield return new WaitForSeconds(WDelay);
		CanAttack = true;
		//Moving = false;
	}

	IEnumerator yaLeD(float WDelay )
	{

		//NewAnimations
		yield return new WaitForSeconds(WDelay);
		CanAttack = true;
		//Moving = false;
	}
}
