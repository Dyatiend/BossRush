using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{

    private Collider collider;
    
    void Start()
    {
        Destroy(gameObject, 7f);
        collider = GetComponent<CapsuleCollider>();
        Invoke(nameof(turnOffCollider), 5f);
    }

    
    void Update()
    {
        
    }

    private void turnOffCollider()
    {
        collider.enabled = false;
    }
}
