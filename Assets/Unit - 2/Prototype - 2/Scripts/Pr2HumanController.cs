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
}
