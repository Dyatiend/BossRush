using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateStun : MonoBehaviour
{
    public int dealingDamage;
    public float stunTime;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Player"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
            collider.GetComponent<Locomotion1>().Stun(stunTime);
        }
    }
}
