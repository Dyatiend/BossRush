using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapKus : MonoBehaviour
{
    public GameObject kastil;
    private void OnTriggerEnter(Collider other)
    {
       
        var val = kastil.GetComponent<Targeting>();
        if (other.tag == val.TargetTag)
        {
            other.GetComponent<Health>().TakeDamage(15);
            if (other.GetComponent<Locomotion>() != null)
                other.GetComponent<Locomotion>().Slow(0.25f, 3);
        }
    }
}
