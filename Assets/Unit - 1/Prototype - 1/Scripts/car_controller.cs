using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_controller : MonoBehaviour
{

    //speed vars
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;
    
    //input for car 1
    public float verticalInput1;
    public float horizontalInput1;

    //input for car 2
    public float verticalInput2;
    public float horizontalInput2;

    public bool car1;
    public bool car2;

    // Update is called once per frame
    void Update()
    {
        //rotation speed calculation
        turnSpeed = speed * 1.80f;

        if(car1)
        {
            //getting the axis for input to control the car 1
            verticalInput1 = Input.GetAxis("Vertical");
            horizontalInput1 = Input.GetAxis("Horizontal");

            //moving the car using W,S that's calculated with real time * speed
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput1);

            if (verticalInput1 == 0)
            {
                //stopping the car rotation while not moving
                horizontalInput1 = 0;
            }
            else
            {
                //rotating the car using A,D
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput1);
            }
        }

        if(car2)
        {
            //getting the axis for input to control car 2
            verticalInput2 = Input.GetAxis("Vertical2");
            horizontalInput2 = Input.GetAxis("Horizontal2");

            //moving the car using arrow keys
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput2);

            if (verticalInput2 == 0)
            {
                //stopping the car rotation while not moving
                horizontalInput2 = 0;
            }
            else
            {
                //rotating the car using arrow keys
                transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput2);
            }

        }

    }
}
