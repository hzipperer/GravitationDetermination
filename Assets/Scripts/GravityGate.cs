using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGate : MonoBehaviour
{
    public string gateDirection;
    public GameObject gate;
    public GameObject player;
    private CharacterController2D controller;

    void Awake()
    {
        controller = player.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gateDirection.Equals(controller.GravityDirection))
        {
            gate.GetComponent<BoxCollider2D>().enabled = false;
            gate.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            gate.GetComponent<BoxCollider2D>().enabled = true;
            gate.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
