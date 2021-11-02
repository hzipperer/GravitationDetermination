using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    [SerializeField] private LayerMask boxLayerMask;
    public CharacterController2D controller;
    public Transform grabDetect;
    public Transform boxHolder;
    private GameObject box;
    private RaycastHit2D grabCheck;


    void Update()
    {
        if (controller.GravityDirection == "Down")
        {
            grabCheck = Physics2D.BoxCast(grabDetect.position, new Vector3(0.75f, 1.25f, 0), 0f, Vector2.right * transform.localScale, 0, boxLayerMask);
        }
        else if (controller.GravityDirection == "Up")
        {
            grabCheck = Physics2D.BoxCast(grabDetect.position, new Vector3(0.75f, 1.25f, 0), 0f, Vector2.left * transform.localScale, 0, boxLayerMask);
        }
        else if (controller.GravityDirection == "Left")
        {
            grabCheck = Physics2D.BoxCast(grabDetect.position, new Vector3(1.25f, 0.75f, 0), 0f, Vector2.down * controller.direction, 0, boxLayerMask);
        }
        else if (controller.GravityDirection == "Right")
        {
            grabCheck = Physics2D.BoxCast(grabDetect.position, new Vector3(1.25f, 0.75f, 0), 0f, Vector2.up * controller.direction, 0, boxLayerMask);
        }
        
        if(grabCheck.collider != null && grabCheck.collider.tag == "Box" && !controller.isDead && !PauseMenu.GameIsPaused)
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
        else if ( (grabCheck.collider == null || grabCheck.collider.tag != "Box") && !controller.canGrab && !controller.isFlipping && !PauseMenu.GameIsPaused)
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
