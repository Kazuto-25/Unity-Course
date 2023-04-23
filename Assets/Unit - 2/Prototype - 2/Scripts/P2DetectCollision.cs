using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2DetectCollision : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameManager.AddScore(10);
        }
    }
}
