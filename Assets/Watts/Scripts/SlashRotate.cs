using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashRotate : MonoBehaviour
{
    public Vector3 pivot;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }
    
    void FixedUpdate()
    {
        transform.RotateAround(pivot, Vector3.up, deltaAngle());
    }
    
    public float duration = 1.0f;
    public float initAngleSpeed = 10;
    private float startTime;

    private float deltaAngle()
    {
        float t = (Time.time - startTime) / duration;
        return Mathf.SmoothStep( initAngleSpeed, 0, t);
    }
}
