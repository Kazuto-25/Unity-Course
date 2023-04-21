using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEnemyBehaviour : MonoBehaviour
{
    public float speed;
    public float destroyRange = -15;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        DogDestroy();
    }

    void DogDestroy()
    {
        if (transform.position.z < destroyRange)
        {
            Destroy(this.gameObject);
        }
    }
}
