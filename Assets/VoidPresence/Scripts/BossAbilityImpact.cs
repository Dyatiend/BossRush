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
            collider.GetComponent<Locomotion1>().Slow(slowing, slowingTime);
        }
        if (collider.tag != ("Boss"))
        {
            GetComponent<ProjectileHit>().PlayHitAnim();
            GetComponent<ProjectileTranslate>().speed = 0f;
        }
    }
}
