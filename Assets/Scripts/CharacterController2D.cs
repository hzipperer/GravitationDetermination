using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D: MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private float nextFlipTime = 0;
    private float cooldownTime = 2;
    private int direction;
    public Animator animator;
    public string GravityDirection;
    private bool onGround;
    private float wallCollision;
    private Rigidbody2D rb;
    private CapsuleCollider2D boxCollider2d;
    public float MovementSpeed = 15;
    private bool isMoving = false;
    public bool canTeleport = true;

    void Awake()
    {
        GravityDirection = "Down";
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2d = gameObject.GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        onGround = IsGrounded();
        wallCollision = wallCollide();
        if (onGround)
        {
            animator.SetBool("onGround", true);
            if (Time.time > nextFlipTime && !isMoving)
            {
                if (Input.GetKeyDown(KeyCode.W) && GravityDirection != "Up")
                {
                    wallAdjust(wallCollision, GravityDirection);
                    GravityDirection = "Up";
                    transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0;
                    Physics2D.gravity = new Vector2(0, 9.8f);
                    nextFlipTime = Time.time + cooldownTime;
                }
                else if (Input.GetKeyDown(KeyCode.S) && GravityDirection != "Down")
                {
                    wallAdjust(wallCollision, GravityDirection);
                    GravityDirection = "Down";
                    transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0;
                    Physics2D.gravity = new Vector2(0, -9.8f);
                    nextFlipTime = Time.time + cooldownTime;
                }
                else if (Input.GetKeyDown(KeyCode.A) && GravityDirection != "Left")
                {
                    wallAdjust(wallCollision, GravityDirection);
                    GravityDirection = "Left";
                    transform.rotation = Quaternion.Euler(Vector3.forward * 270);
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0;
                    Physics2D.gravity = new Vector2(-9.8f, 0);
                    nextFlipTime = Time.time + cooldownTime;
                }
                else if (Input.GetKeyDown(KeyCode.D) && GravityDirection != "Right")
                {
                    wallAdjust(wallCollision, GravityDirection);
                    GravityDirection = "Right";
                    transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0;
                    Physics2D.gravity = new Vector2(9.8f, 0);
                    nextFlipTime = Time.time + cooldownTime;
                }
            }

            if (GravityDirection == "Down")
            {
                var movement = Input.GetAxis("Horizontal");
                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
                animator.SetFloat("Speed", Mathf.Abs(movement));
                if (movement > 0)
                {
                    direction = 1;
                    transform.localScale = new Vector3(direction, 1, 1);
                    isMoving = true;
                }
                else if (movement < 0)
                {
                    direction = -1;
                    transform.localScale = new Vector3(direction, 1, 1);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
            }
            else if (GravityDirection == "Up")
            {
                var movement = Input.GetAxis("Horizontal");
                transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
                animator.SetFloat("Speed", Mathf.Abs(movement));
                if (movement > 0)
                {
                    direction = -1;
                    transform.localScale = new Vector3(direction, 1, 1);
                }
                else if (movement < 0)
                {
                    direction = 1;
                    transform.localScale = new Vector3(direction, 1, 1);
                }
            }
            else if (GravityDirection == "Right")
            {
                var movement = Input.GetAxis("Vertical");
                transform.position += new Vector3(0, movement, 0) * Time.deltaTime * MovementSpeed;
                animator.SetFloat("Speed", Mathf.Abs(movement));
                if (movement > 0)
                {
                    direction = 1;
                    transform.localScale = new Vector3(direction, 1, 1);
                    isMoving = true;
                }
                else if (movement < 0)
                {
                    direction = -1;
                    transform.localScale = new Vector3(direction, 1, 1);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
            }
            else if (GravityDirection == "Left")
            {
                var movement = Input.GetAxis("Vertical");
                transform.position += new Vector3(0, movement, 0) * Time.deltaTime * MovementSpeed;
                animator.SetFloat("Speed", Mathf.Abs(movement));
                if (movement > 0)
                {
                    direction = -1;
                    transform.localScale = new Vector3(direction, 1, 1);
                    isMoving = true;
                }
                else if (movement < 0)
                {
                    direction = 1;
                    transform.localScale = new Vector3(direction, 1, 1);
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
            }
        }
        else
        {
            animator.SetBool("onGround", false);
        }

    }

    private bool IsGrounded()
    {
        float extraHeight = .25f;
        if (GravityDirection == "Down")
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
            return raycastHit.collider != null;
        }
        else if (GravityDirection == "Up")
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.up, extraHeight, platformLayerMask);
            return raycastHit.collider != null;
        }
        else if (GravityDirection == "Left")
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.left, extraHeight, platformLayerMask);
            return raycastHit.collider != null;
        }
        else
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.right, extraHeight, platformLayerMask);
            return raycastHit.collider != null;
        }
    }

    private float wallCollide()
    {
        float extraHeight = 4f;
        if (GravityDirection == "Down" || GravityDirection == "Up")
        {
            RaycastHit2D leftHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.left, extraHeight, platformLayerMask);
            RaycastHit2D rightHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.right, extraHeight, platformLayerMask);
            if (leftHit.collider != null)
            {
                return leftHit.distance;
            }
            else if (rightHit.collider != null)
            {
                return rightHit.distance * -1;
            }
            else
            {
                return 0f;
            }
        }
        else
        {
            RaycastHit2D leftHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, extraHeight, platformLayerMask);
            RaycastHit2D rightHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.up, extraHeight, platformLayerMask);
            if (leftHit.collider != null)
            {
                return leftHit.distance;
            }
            else if (rightHit.collider != null)
            {
                return rightHit.distance * -1;
            }
            else
            {
                return 0f;
            }
        }
    }

    private void wallAdjust(float collisionDirection, string gravityDirection)
    {
        if (gravityDirection == "Down" || gravityDirection == "Up")
        {
            if (collisionDirection < 0)
            {
                transform.position += new Vector3(-4 - collisionDirection, 0, 0);
            }
            else if (collisionDirection > 0)
            {
                transform.position += new Vector3(4 - collisionDirection, 0, 0);
            }
        }
        else
        {
            if (collisionDirection < 0)
            {
                transform.position += new Vector3(0, -4 - collisionDirection, 0);
            }
            else if (collisionDirection > 0)
            {
                transform.position += new Vector3(0, 4 - collisionDirection, 0);
            }
        }
    }

}
