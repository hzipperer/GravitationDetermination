using UnityEngine;

public class PressurePlate : MonoBehaviour
{
	public Animator animator;

	public GameObject door;

	private void OnTriggerStay2D(Collider2D collider)
	{
		animator.SetBool("IsPressed", value: true);
		door.SetActive(value: false);
	}

	private void OnTriggerExit2D(Collider2D collider)
	{
		animator.SetBool("IsPressed", value: false);
		door.SetActive(value: true);
	}
}
