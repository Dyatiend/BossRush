using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapContiniousEffect : CharacterEffect
{
    protected override void action(GameObject other)
    {
        if (other.GetComponent<ContiniousDamage>() == null)
        {
            other.AddComponent<ContiniousDamage>();
        }
    }
}
