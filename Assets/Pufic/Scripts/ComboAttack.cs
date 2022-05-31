using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : Skill
{
    public GameObject claw;
    public Transform leftPos, rightPos;
    public override bool NeedsMouseRotation()
    {
        return true;
    }

    public override SkillType Type()
    {
        return SkillType.Ultimate;
    }

    protected override void Action()
    {
        // GetComponentInChildren<Targeting>().ConfigureTargetingAs(gameObject.tag);
        Invoke(nameof(leftFlyClaws), 0.2f);
        Invoke(nameof(rightFlyClaws), 0.3f);
        Invoke(nameof(leftFlyClaws), 0.4f);
        Invoke(nameof(rightFlyClaws), 0.5f);
    }

    protected override float ActiveTime()
    {
        return 0.95f;
    }

    protected override float HoldUpTime()
    {
        return 0;
    }

    protected override float ReloadTime()
    {
        return 0;
    }

    void leftFlyClaws()
    {
        GameObject claw_ = Instantiate(claw, leftPos.position, leftPos.rotation);
        claw_.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
    }

    void rightFlyClaws()
    {
        GameObject claw_ = Instantiate(claw, rightPos.position, rightPos.rotation);
        claw_.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
    }
}
