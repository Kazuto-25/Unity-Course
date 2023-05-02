using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class target : MonoBehaviour
{
    private Rigidbody rb;
    public GameManagerP5 gameManager;
    public ParticleSystem explosion;


    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnRange = 1;
    public int scoreValue;
    public int lifeValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerP5>();

        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    void OnMouseDown()
    {
        if(!gameManager.gameOver)
        {
            gameManager.UpdateScore(scoreValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            Destroy(this.gameObject);
        }  
    }

    Vector3 RandomForce() 
    { 
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        
        if (!gameObject.CompareTag("Enemy"))
        {
            gameManager.lives -= 1;
        }
    }
}
