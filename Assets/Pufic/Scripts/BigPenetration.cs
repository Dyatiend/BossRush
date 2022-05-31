using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPenetration : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var val = GetComponent<Targeting>();
        if (other.tag == val.TargetTag)
        {
            other.GetComponent<Health>().TakeDamage(1000);
        }
    }
}
