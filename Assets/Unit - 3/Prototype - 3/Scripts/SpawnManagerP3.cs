using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerP3 : MonoBehaviour
{
    public GameObject[] obsticlePrefabs;
    public int obsticleCount;
    public float startTime = 2;
    public float delayTime = 2;

    public PlayerControllerP3 playerContollerP3;

    private void Start()
    {
        playerContollerP3 = GameObject.Find("Player").GetComponent<PlayerControllerP3>();
        InvokeRepeating("SpawnObsticles", startTime, delayTime);
        
    }

    void SpawnObsticles()
    {
        if (!playerContollerP3.gameOver)
        {
            obsticleCount = Random.Range(0, 5);
            Instantiate(obsticlePrefabs[obsticleCount], obsticlePrefabs[obsticleCount].transform.position, obsticlePrefabs[obsticleCount].transform.rotation);
        }
    }
}
