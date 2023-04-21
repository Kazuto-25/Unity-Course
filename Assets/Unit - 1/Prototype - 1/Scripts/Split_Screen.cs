using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_Screen : MonoBehaviour
{
    void Start()
    {
        Camera player1Camera = GameObject.Find("Player 1 Camera").GetComponent<Camera>();
        Camera player2Camera = GameObject.Find("Player 2 Camera").GetComponent<Camera>();

        Rect player1Viewport = new Rect(0, 0, 0.5f, 1);
        Rect player2Viewport = new Rect(0.5f, 0, 0.5f, 1);

        player1Camera.rect = player1Viewport;
        player2Camera.rect = player2Viewport;
    }
}
