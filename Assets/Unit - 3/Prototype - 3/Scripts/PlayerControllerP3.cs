using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerP3 : MonoBehaviour
{
    public float jumpForce;
    public float gravityModifier;
    public float doubleJumpForce;

    public bool isGrounded = true;
    public bool gameOver = false;
    public bool doubleJumpUsed = false;

    private Rigidbody rb;
    private Animator animator;
    private AudioSource playerSFX;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public AudioSource music;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerSFX = GetComponent<AudioSource>();
        jumpForce = GetComponent<Rigidbody>().mass * 30;
        doubleJumpForce = GetComponent <Rigidbody>().mass * 20;

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        GameOver();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosionParticle.Play();
            music.enabled = false;
            playerSFX.PlayOneShot(crashSound, 2f);
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            dirtParticle.Stop();
            isGrounded = false;
            animator.SetTrigger("Jump_trig");
            playerSFX.PlayOneShot(jumpSound, 2f);

            doubleJumpUsed = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && !doubleJumpUsed)
        {
            doubleJumpUsed = true;
            rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            animator.Play("Running_Jump", 3, 0f);
            playerSFX.PlayOneShot(jumpSound, 1.0f);
        }


    }

    public void GameOver()
    {
        if (gameOver)
        {
            dirtParticle.Stop();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);
        }

        else
        {
            Jump();
        }
    }
}
