using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEnemyBehaviour : MonoBehaviour
{
    public GameManager gameManager;

    public float speed;
    public float destroyRange1 = -15;
    public float destroyRange2 = 25;
    public float destroyRange3 = -25;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        DogDestroy();
    }

    void DogDestroy()
    {
        if (transform.position.z < destroyRange1 || transform.position.x > destroyRange2 || transform.position.x < destroyRange3)
        {
            Destroy(this.gameObject);
            gameManager.AddLives(-1);
        }
    }
}
