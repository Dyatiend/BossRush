using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goo_ability : Skill
{
    public override SkillType Type()
    {
        return SkillType.Ability;
    }

    public override bool NeedsMouseRotation()
    {
        return true;
    }

    protected override float HoldUpTime()
    {
        return 0;
    }

    protected override float ActiveTime()
    {
        return 0;
    }

    protected override float ReloadTime()
    {
        return 0;
    }

    protected override void Action()
    {
      
    }
}
