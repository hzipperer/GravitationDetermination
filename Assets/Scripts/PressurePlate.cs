using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    public Animator animator;

    void OnCollisionStay2D(Collision2D collider)
    {
        animator.SetBool("IsPressed", true);
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        animator.SetBool("IsPressed", false);
    }
}
