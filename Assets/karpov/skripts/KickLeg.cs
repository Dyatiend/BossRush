using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickLeg : MonoBehaviour
{
    public int dealingDamage;
    public float stunTime;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag(other.tag))
        {
            if(other.tag == ("Player") || other.tag == ("Boss"))
            {
                other.GetComponent<Health>().TakeDamage(dealingDamage);
                other.GetComponent<Locomotion>().Stun(stunTime);
            }
            
        }
    }
}
