using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityImpact : MonoBehaviour
{
    public int dealingDamage;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Boss"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
        }
        if (collider.tag != ("Player"))
        {
            GetComponent<ProjectileHit>().PlayHitAnim();
            GetComponent<ProjectileTranslate>().speed = 0f;
        }
    }
}
