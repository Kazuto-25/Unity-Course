﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(15, 2.5f, 0);


    void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}