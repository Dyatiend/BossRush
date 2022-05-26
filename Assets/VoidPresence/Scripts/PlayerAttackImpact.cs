using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackImpact : MonoBehaviour
{
    public int dealingDamage;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Boss"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
            Hit(collider);
        }
    }

    public void Hit(Collider collider)
    {
        if (collider.tag != ("Player") && collider.tag != ("AbilityObject"))
        {
            GetComponent<ProjectileHit>().PlayHitAnim();
            GetComponent<ProjectileTranslate>().speed = 0f;
        }
    }
}
