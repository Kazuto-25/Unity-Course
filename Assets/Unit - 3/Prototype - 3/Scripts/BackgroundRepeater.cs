using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public float speed;
    public Vector3 startPos;
    public float repeatWidth;

    PlayerControllerP3 playerContollerP3;

    private void Start()
    {
        playerContollerP3 = GameObject.Find("Player").GetComponent<PlayerControllerP3>();
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerContollerP3.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (transform.position.x < startPos.x - repeatWidth)
            {
                transform.position = startPos;
            }
        } 
    }
}
