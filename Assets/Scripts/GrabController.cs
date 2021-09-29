using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public CharacterController2D controller;
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist = 2f;
    private GameObject box;
    private RaycastHit2D grabCheck;


    void Update()
    {
        if (controller.GravityDirection == "Down")
        {
            grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        }
        else if (controller.GravityDirection == "Up")
        {
            grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.left * transform.localScale, rayDist);
        }
        else if (controller.GravityDirection == "Left")
        {
            grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.down * controller.direction, rayDist);
        }
        else if (controller.GravityDirection == "Right")
        {
            grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.up * controller.direction, rayDist);
        }
        
        if(grabCheck.collider != null && grabCheck.collider.tag == "Box" && !controller.isDead)
        {

            if (Input.GetKeyDown(KeyCode.F) && controller.canGrab && !controller.isFlipping )
            {
                controller.canGrab = false;
                box = grabCheck.collider.gameObject;
                box.GetComponent<BoxCollider2D>().enabled = false;
                box.transform.parent = boxHolder;
                box.transform.position = boxHolder.position;
                box.GetComponent<Rigidbody2D>().isKinematic = true;
            }

            if (!controller.canGrab)
            {
                box.transform.position = boxHolder.position;
            }
        }
        else if (grabCheck.collider == null && !controller.canGrab && !controller.isFlipping)
        {
            if (Input.GetKeyDown(KeyCode.F) || controller.isDead)
            {
                controller.canGrab = true;
                box.GetComponent<BoxCollider2D>().enabled = true;
                box.transform.parent = null;
                box.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
