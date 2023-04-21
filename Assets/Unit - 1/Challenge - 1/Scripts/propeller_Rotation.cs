using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propeller_Rotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
