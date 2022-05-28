using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapGuaranteedEffect : CharacterEffect
{
    protected override void action(GameObject other)
    {
        other.GetComponent<Health>().TakeDamage(5);
    }
}
