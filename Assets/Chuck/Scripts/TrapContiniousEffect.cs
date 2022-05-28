using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapContiniousEffect : CharacterEffect
{
    protected override void action(GameObject other)
    {
        other.gameObject.AddComponent<ContiniousDamage>();
    }
}
