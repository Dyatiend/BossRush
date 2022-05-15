using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimateImpact : MonoBehaviour
{
    public int dealingDamage;

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == ("Boss"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
        }
    }
}
