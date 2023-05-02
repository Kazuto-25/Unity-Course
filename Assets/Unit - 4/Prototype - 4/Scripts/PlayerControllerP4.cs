using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerControllerP4 : MonoBehaviour
{
    public float speed;
    private float powerUpStrenth = 10f;
    public bool hasPowerUp = false;
    public float countDownTimer = 7f;
    public float smashForce;
    public bool isGrounded;

    [SerializeField]
    private GameObject powerUpIndicator;
    private GameObject focalPoint;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        if(isGrounded)
        {
            float forwardInput = Input.GetAxis("Vertical");
            rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        }

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if(transform.position.y < -50)
        {
            transform.position = new Vector3(0, 16f, 0);
        }

        if (transform.position.y < -1.5f &&  transform.position.y > -2f)
        {
            isGrounded = true;
        }

        else
        {
            isGrounded = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            SmashAttack();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.SetActive(true);
        }
    }

    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(countDownTimer);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrenth, ForceMode.Impulse);

            Debug.Log("Collided with: " +  collision.gameObject.name + "& PowerUp is set to: " + hasPowerUp);
        }

        else if (collision.gameObject.CompareTag("Enemy") && !hasPowerUp)
        {
            Debug.Log("Collided with: " + collision.gameObject.name + "& PowerUp is set to: " + hasPowerUp);
        }
    }

    private void SmashAttack()
    {
        rb.AddForce(Vector3.up * smashForce , ForceMode.Impulse);
    }
}
