using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLineGuarantedEffect : CharacterEffect
{
    protected override void action(GameObject other)
    {
        if (Random.Range(0.0f, 100.0f) >= 10)
        {
            other.GetComponent<Health>().TakeDamage(20);
        }
        other.GetComponent<Health>().TakeDamage(10);
    }
}
