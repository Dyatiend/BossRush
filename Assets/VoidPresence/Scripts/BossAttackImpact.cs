using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackImpact : MonoBehaviour
{
    public int dealingDamage;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Player"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
        }
        if (collider.tag != ("Boss"))
        {
            GetComponent<ProjectileHit>().PlayHitAnim();
            GetComponent<ProjectileTranslate>().speed = 0f;
        }
    }
}
