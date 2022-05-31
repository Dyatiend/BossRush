using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goo_attack : Skill
{
    public override SkillType Type()
    {
        return SkillType.Attack;
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
        return 0.5f;
    }

    protected override float ReloadTime()
    {
        return 0;
    }

    public GameObject legCollider;
    protected override void Action()
    {
        legCollider.SetActive(true);
        legCollider.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
        Invoke(nameof(disableCollider),ActiveTime());
    }

    protected void disableCollider()
    {
        legCollider.SetActive(false);
    }
    
    
}
