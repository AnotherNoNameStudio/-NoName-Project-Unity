using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 3;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// look at edit -> project settings -> input
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
			transform.Translate (new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f));
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
			transform.Translate (new Vector2 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime));
		}

		// update values of Animator's MoveX and MoveY
		anim.SetFloat("MoveX", Input.GetAxisRaw(("Horizontal")));
		anim.SetFloat("MoveY", Input.GetAxisRaw(("Vertical")));
	}
}
