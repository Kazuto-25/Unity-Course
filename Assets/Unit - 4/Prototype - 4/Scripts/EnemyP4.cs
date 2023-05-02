using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SubsystemsImplementation;

public class EnemyP4 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;

    public bool isGrounded;
    public float speed;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Chase();
        Fall();
    }

    void Chase()
    {   
        if (isGrounded)
        {
            Vector3 playerPos = (player.transform.position - transform.position).normalized;
            rb.AddForce(playerPos * speed);
        }
    }

    void Fall()
    {
        if(transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.position.y < 1 && transform.position.y > -2f)
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }
    }
}
