using UnityEngine;

public class PressurePlate : MonoBehaviour
{
	public Animator animator;

	public GameObject door;

	private void OnCollisionStay2D(Collision2D collider)
	{
		animator.SetBool("IsPressed", value: true);
		door.SetActive(value: false);
	}

	private void OnCollisionExit2D(Collision2D collider)
	{
		animator.SetBool("IsPressed", value: false);
		door.SetActive(value: true);
	}
}
