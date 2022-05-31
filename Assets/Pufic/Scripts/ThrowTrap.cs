using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTrap : Skill
{
    public GameObject trap;
    public Transform trapPos;
    public float throwForce;
    public override bool NeedsMouseRotation()
    {
        return true;
    }

    public override SkillType Type()
    {
        return SkillType.Ability;
    }

    protected override void Action()
    {
        GameObject trap_ = Instantiate(trap, trapPos.position, trapPos.rotation);
        Rigidbody rb = trap_.GetComponent<Rigidbody>();
        trap_.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
        rb.AddForce(trapPos.transform.forward * throwForce, ForceMode.VelocityChange);
    }

    protected override float ActiveTime()
    {
        return 0.9f;
    }

    protected override float HoldUpTime()
    {
        return 0.5f;
    }

    protected override float ReloadTime()
    {
        return 10;
    }
}
