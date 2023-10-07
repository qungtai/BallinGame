using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    void Update()
    {
        transform.Rotate(new Vector3(0,speed* Time.deltaTime,0));
    }
}
