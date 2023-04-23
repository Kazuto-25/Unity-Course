using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundC3 : MonoBehaviour
{
    public Vector3 startPos;
    public float repeatWidth;

    PlayerControllerC3 playerControllerC3;

    private void Start()
    {
        playerControllerC3 = GameObject.Find("Player").GetComponent<PlayerControllerC3>();
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
    }

    private void Update()
    {
        if (!playerControllerC3.gameOver)
        {
            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }

 
}


