using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPufic : Skill
{
    public GameObject kastil;
    public override bool NeedsMouseRotation()
    {
        return true;
    }

    public override SkillType Type()
    {
        return SkillType.Attack;
    }

    protected override void Action()
    {
        kastil.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
    }

    protected override float ActiveTime()
    {
        return 1.3f;
    }

    protected override float HoldUpTime()
    {
        return 0;
    }

    protected override float ReloadTime()
    {
        return 0;
    }
}

