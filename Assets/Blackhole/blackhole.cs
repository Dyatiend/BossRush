using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackhole : MonoBehaviour
{
    public Transform center;
    public float force;
    public float minForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        Controller controller = collider.transform.GetComponent<Controller>();
        Vector3 vect = center.position - collider.transform.position;
        float distance = vect.magnitude;
        Vector3 direction = vect / distance;
        //controller.Move(direction.z, direction.x, force / distance + minForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
