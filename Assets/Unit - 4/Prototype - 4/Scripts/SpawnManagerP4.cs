using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerP4 : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject[] enemyPrefabs;

    public int enemyCount;
    public float spawnRange;
    public int waveNumber = 1;

    private void Start()
    {
        WaveSpawn(waveNumber);
        PowerUpSpawn();
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyP4>().Length;

        if(enemyCount == 0)
        {
            PowerUpSpawn();
            waveNumber++;
            WaveSpawn(waveNumber);
        }
    }

    private Vector3 GenarateSpawnPos()

    { 
        float spawnPosX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float spawnPosY = spawnRange;
        float spwanPosZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spwanPosZ);

        return randomPos;
    }

    private void WaveSpawn(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefabs[UnityEngine.Random.Range(0, 3)], GenarateSpawnPos(), enemyPrefabs[UnityEngine.Random.Range(0, 3)].transform.rotation);
        }
    }

    private void PowerUpSpawn()
    {
        
        Instantiate(powerUp, new Vector3(UnityEngine.Random.Range(-18, 18), -0.46f, UnityEngine.Random.Range(-18, 18)), powerUp.transform.rotation);
    }
}
