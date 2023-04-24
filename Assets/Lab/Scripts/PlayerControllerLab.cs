using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLab : MonoBehaviour
{
    Rigidbody rb;


    public float speed;
    public float sprintSpeed = 15;
    public float normalSpeed = 10;
    public float verticalInput;
    public float horizontalInput;
    public float jumpForce;
    public float gravityModifier;
    private float zBound = 10;
    private float xBound = 18;

    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        jumpForce = rb.mass * 30;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Sprint();
        PostionLimiter();
    }

    private void OnCollisionEnter(Collision other)
    {
        //checking if player is colliding with ground or not
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void Movement()
    {
        //using vertical and horzontal inputs from old Input system
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
    }

    private void Jump()
    {
        //jumpimg when player is on ground
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

    private void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        else
        {
            speed = normalSpeed;
        }
    }

    private void PostionLimiter()
    {
        // for Off-Screen of z axis
        if(transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        //for Off-Screen of x axis
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }
}
