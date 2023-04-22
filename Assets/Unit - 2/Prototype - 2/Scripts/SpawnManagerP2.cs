using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerP2 : MonoBehaviour
{
    public GameObject[] dogPrefabs;
    public GameObject[] negRotPrefabs;
    public GameObject[] posRotPrefabs;
    public int dogIndex;
    public int negIndex;
    public int posIndex;
    public float startDelay = 5f;
    public float spawnIntervals = 2f;
    public GameObject player;

    public float randomTime;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnDogs", startDelay, spawnIntervals);
    }

    private void Update()
    {
        randomTime += Time.deltaTime;

        if(randomTime >= 5)
        {
            randomTime = 0;
        }
    }

    void SpawnDogs()
    {
        if (player != null)
        {
            if(randomTime > 0f && randomTime < 1.8f)
            {
                Vector3 spawnPosZ = new Vector3(Random.Range(-15, 15), 0, 19);
                dogIndex = Random.Range(0, 3);
                Instantiate(dogPrefabs[dogIndex], spawnPosZ, dogPrefabs[dogIndex].transform.rotation);
            }
            
            else if (randomTime > 1.81f && randomTime < 3.8f)
            {
                Vector3 spawnPosX1 = new Vector3(20, 0, Random.Range(3, 15));
                negIndex = Random.Range(0, 2);
                Instantiate(negRotPrefabs[negIndex], spawnPosX1, negRotPrefabs[negIndex].transform.rotation);
            }

            else
            {
                Vector3 spawnPosX2 = new Vector3(-20, 0, Random.Range(3, 15));
                posIndex = Random.Range(0, 2);
                Instantiate(posRotPrefabs[posIndex], spawnPosX2, posRotPrefabs[posIndex].transform.rotation);
            }
  
        }

        else
        {
            Debug.Log("Game over");
        }

    }
}
