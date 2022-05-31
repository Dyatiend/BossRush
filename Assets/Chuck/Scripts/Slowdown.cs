using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : CharacterContiniousEffect
{
    private int slowdownEffect;

    protected override void action()
    {
        throw new System.NotImplementedException();
    }

    protected override float duration()
    {
        return 10f;
    }

    protected override void setUpAction()
    {
        GetComponent<Locomotion>().Slow(0.9f, duration());
    }

}
