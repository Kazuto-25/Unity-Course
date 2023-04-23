using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pr2HumanController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float xRange;
    public float zRange;
    public GameObject foodProjectile;
    public GameManager gameManager;
    public float invincibilityTime;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * Vector3.right * speed * Time.deltaTime);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodProjectile, transform.position, foodProjectile.transform.rotation);
        }

        PositionLimiter();



        if (invincibilityTime > 2)
        {
            invincibilityTime = 0;
        }
    }


    void PositionLimiter()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        else if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        else if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            Destroy(other.gameObject);

            if (invincibilityTime == 0)
            {
                gameManager.AddLives(-1);
                invincibilityTime += Time.deltaTime;
            }

            else
            {
                Debug.Log("is Invincible");
            }
        }
    }
}
