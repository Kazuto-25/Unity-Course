using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
