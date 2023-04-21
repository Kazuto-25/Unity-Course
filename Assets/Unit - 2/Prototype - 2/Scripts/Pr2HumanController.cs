using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pr2HumanController : MonoBehaviour
{
    public float horizontalInput;
    public float speed;
    public float xRange;
    public GameObject foodProjectile;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * Vector3.right * speed * Time.deltaTime);

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
    }
}
