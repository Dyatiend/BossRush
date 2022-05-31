using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Skill
{
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
        /*List<Targeting> targets = */
        //GetComponentInChildren<Targeting>().ConfigureTargetingAs(gameObject.tag);
        //Get
    }

    protected override float ActiveTime()
    {
        return 1.8f;
    }

    protected override float HoldUpTime()
    {
        return 0;
    }

    protected override float ReloadTime()
    {
        return 0;
    }

    public override bool BossUseConditions()
    {
        bool isReload = base.BossUseConditions();

        if (isReload)
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            if (Vector3.Distance(playerPosition, gameObject.transform.position) > 1.3)
            {
                isReload = false;
            }
        }

        return isReload;
    }
}
