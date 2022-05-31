using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContiniousDamage : CharacterContiniousEffect
{
    private int deltaHP;

    protected override float duration()
    {
        return 5.0f;
    }

    protected override void setUpAction()
    {
        deltaHP = (int)(GetComponent<Health>().maxHealhPoints / 10 / duration());
    }

    private float currentSec = 0;

    protected override void action()
    {
        currentSec += Time.deltaTime;
        if (currentSec > 1)
        {
            GetComponent<Health>().TakeDamage(deltaHP);
            currentSec = 0;
        }
    }
}
