using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public GameObject otherPortal;
    public GameObject player;
    private CharacterController2D controller;

    void Awake()
    {
        controller = player.GetComponent<CharacterController2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (controller.canTeleport)
        {
            Teleport(other);
        }
    }

    void Teleport(Collider2D other)
    {
        other.transform.position = otherPortal.transform.position;
        controller.canTeleport = false;
        StartCoroutine(Cooldown());
    }
    
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        controller.canTeleport = true;
    }
}
