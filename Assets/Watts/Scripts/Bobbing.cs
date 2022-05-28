using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    private Vector3 initPos;
    public float bobAmount = 0.5f;
    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        transform.position = initPos + Vector3.up * (bobAmount * Mathf.Sin(Time.time));
        transform.rotation = Quaternion.AngleAxis(Time.time, Vector3.up);
    }
}
