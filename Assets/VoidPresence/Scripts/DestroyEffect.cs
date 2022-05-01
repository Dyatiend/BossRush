using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1f;


    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
