using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
	public Animator animator;
	public float trampolinePower;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		animator.SetBool("isPressed", value: true);
		StartCoroutine(wait(collider));
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		animator.SetBool("isPressed", value: false);
	}

	IEnumerator wait(Collider2D collider)
    {
		yield return new WaitForSeconds(.2f);
		animator.SetBool("isPressed", value: false);
		collider.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * trampolinePower);
	}
}
