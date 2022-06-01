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
            Hit(collider);
        }
    }

    public void Hit(Collider collider)
    {
        if (collider.tag != ("Boss") && collider.tag != ("AbilityObject"))
        {
            GetComponent<ProjectileHit>().PlayHitAnim();
            GetComponent<MyProjectileTranslate>().speed = 0f;
        }
    }
}
