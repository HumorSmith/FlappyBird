using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {
	private bool isDead = false;
	private Rigidbody2D rb2d;
	public float upForce = 200f;                   //Upward force of the "flap".
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead==false){ //if not dead.
			if(Input.GetMouseButtonDown(0)){ //mouse down
				rb2d.velocity = Vector2.zero;
				//  new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
				anim.SetTrigger ("Flap");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		isDead = true;
		anim.SetTrigger ("Die");
		GameController.instance.BirdDied ();
	}
}
