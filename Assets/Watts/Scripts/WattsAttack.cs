using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WattsAttack : Skill
{
    
    public override SkillType Type()
    {
        return SkillType.Attack;
    }

    public override bool NeedsMouseRotation()
    {
        return false;
    }

    protected override float ActiveTime()
    {
        return 0.8f;
    }

    protected override float ReloadTime()
    {
        return 0.2f;
    }

    protected override float HoldUpTime()
    {
        return 0.35f;
    }

    public GameObject slashCollider;

    protected override void Action()
    {
        Vector3 origin = gameObject.transform.position + Vector3.up * 1.2f + transform.TransformDirection(Vector3.forward) * 0.5f;
        GameObject slash = Instantiate(slashCollider, origin + transform.TransformDirection(Vector3.right), Quaternion.LookRotation(transform.TransformDirection(Vector3.right)));
        SlashRotate r = slash.GetComponent<SlashRotate>();
        r.pivot = origin;
        slash.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
        slash.GetComponent<ObjectLifetime>().destroyAfter = r.duration;
    }
}
