using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerC2 : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 4;
    private float spawnPosY = 30;
    public int ballSpawnerRange;
    private float startDelay = 2f;
    private float spawnInterval = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        ballSpawnerRange = Random.Range(0, 3);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballSpawnerRange], spawnPos, ballPrefabs[ballSpawnerRange].transform.rotation);
    }

}
