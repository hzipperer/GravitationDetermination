using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySuppression : MonoBehaviour
{
    public GameObject player;
    private CharacterController2D controller;

    void Awake()
    {
        controller = player.GetComponent<CharacterController2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            controller.canFlip = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            controller.canFlip = true;
        }
    }
}
