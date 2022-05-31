using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiskovUltimate : Skill
{
    // Start is called before the first frame update
    public override SkillType Type()
    {
        return SkillType.Ultimate;
    }

    public override bool NeedsMouseRotation()
    {
        return false;
    }

    protected override float HoldUpTime()
    {
        return 4.4f;
    }

    protected override float ActiveTime()
    {
        return 9f;
    }

    protected override float ReloadTime()
    {
        return 2;
    }

    public int playerDamage = 20;
    public int bossDamage = 25;
    protected override void Action()
    {
        gameObject.GetComponent<Health>().TakeDamage(10);
        Targeting targeting = gameObject.GetComponent<Targeting>();
        targeting.ConfigureTargetingAs(gameObject.tag);
        if (CompareTag("Player"))
        {
            GameObject.FindWithTag(targeting.TargetTag).GetComponent<Health>().TakeDamage(playerDamage);
        }
        else
        {
            GameObject.FindWithTag(targeting.TargetTag).GetComponent<Health>().TakeDamage(bossDamage);
        }
        
    }
    
}
