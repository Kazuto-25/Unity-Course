using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerP2 : MonoBehaviour
{
    public GameObject[] dogPrefabs;
    public int dogIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-15, 15), 0, 19);
        dogIndex = Random.Range(0, 3);

        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(dogPrefabs[dogIndex], spawnPos, dogPrefabs[dogIndex].transform.rotation);
        }
    }
}
