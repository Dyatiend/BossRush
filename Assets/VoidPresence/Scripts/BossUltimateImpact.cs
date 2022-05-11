using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimateImpact : MonoBehaviour
{
    public int dealingDamage;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == ("Player"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
        }
    }
}
