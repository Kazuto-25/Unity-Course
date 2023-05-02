using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCameraP4 : MonoBehaviour
{
    public float speed;
    public float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, speed * Time.deltaTime * horizontalInput);
    }
}
