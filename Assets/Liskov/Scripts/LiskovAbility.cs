using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiskovAbility : Skill
{
    // Start is called before the first frame update
    public override SkillType Type()
    {
        return SkillType.Ability;
    }

    public override bool NeedsMouseRotation()
    {
        return false;
    }

    protected override float HoldUpTime()
    {
        return 1.3f;
    }

    protected override float ActiveTime()
    {
        return 1.3f;
    }

    protected override float ReloadTime()
    {
        return 3;
    }

    public int heal = 10;
    protected override void Action()
    {
        gameObject.GetComponent<Health>().Heal(heal);
    }
    
}
