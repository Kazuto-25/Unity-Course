using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProjectile : MonoBehaviour
{
    public float speed;
    public float destroyRange = 35;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        FoodDestroy();
    }

    void FoodDestroy()
    {
        if (transform.position.z > destroyRange)
        {
            Destroy(this.gameObject);
        }
    }
}
