using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{ 
	public Animator animator;

	public GameObject crate;

	public GameObject player;

	private CharacterController2D controller;

	private Vector3 originalPos;
	
	void Awake()
    {
		originalPos = new Vector3(crate.transform.position.x, crate.transform.position.y, crate.transform.position.z);
		controller = player.GetComponent<CharacterController2D>();
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		animator.SetBool("IsPressed", value: true);
		controller.canGrab = true;
		crate.GetComponent<BoxCollider2D>().enabled = true;
		crate.transform.parent = null;
		crate.GetComponent<Rigidbody2D>().isKinematic = false;
		crate.transform.position = originalPos;
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		animator.SetBool("IsPressed", value: false);
	}
}
