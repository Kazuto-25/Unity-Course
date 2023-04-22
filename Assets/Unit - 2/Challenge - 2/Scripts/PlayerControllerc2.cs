using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerc2 : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnDelay = 1f;

    private bool canSpawnDog = true;

    // Update is called once per frame
    void Update()
    {
        if (canSpawnDog && Input.GetKeyDown(KeyCode.Space))
        {
            canSpawnDog = false;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            Invoke("EnableSpawnDog", spawnDelay);
        }
    }

    // Enables the player to spawn another dog
    void EnableSpawnDog()
    {
        canSpawnDog = true;
    }
}
