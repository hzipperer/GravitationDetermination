using UnityEngine;


public class GravityGate : MonoBehaviour
{
	public string gateDirection;

	public GameObject gate;

	public GameObject player;

	public GameObject glow;

	private CharacterController2D controller;

	private void Awake()
	{
		controller = player.GetComponent<CharacterController2D>();
	}

	private void Update()
	{
		if (gateDirection.Equals(controller.GravityDirection))
		{
			gate.GetComponent<BoxCollider2D>().enabled = false;
			glow.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.green;
		}
		else
		{
			gate.GetComponent<BoxCollider2D>().enabled = true;
			glow.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.red;
		}
	}
}
