using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSlowdownEffect : CharacterEffect
{
    protected override void action(GameObject other)
    {
        if (other.GetComponent<Slowdown>() == null)
        {
            other.AddComponent<Slowdown>();
        }
    }
}
