using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLineContiniousEffect : CharacterEffect
{
    protected override void action(GameObject other)
    {
        if (other.GetComponent<HighContiniousDamage>() == null)
        {
            other.AddComponent<HighContiniousDamage>();
        }
    }
}
