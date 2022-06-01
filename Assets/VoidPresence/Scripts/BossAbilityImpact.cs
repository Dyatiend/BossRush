using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityImpact : MonoBehaviour
{
    public int dealingDamage;
    public float slowing; 
    public float slowingTime;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Player"))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
            collider.GetComponent<Locomotion>().Slow(slowing, slowingTime);
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
