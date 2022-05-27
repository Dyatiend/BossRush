using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLine : Skill
{
    public Transform Trap;

    public override SkillType Type()
    {
        return SkillType.Ultimate;
    }

    protected override float ReloadTime()
    {
        return 20.0f;
    }

    protected override float HoldUpTime()
    {
        return 2.3f;
    }

    protected override float ActiveTime()
    {
        return 0.1f;
    }

    protected override void Action()
    {
        Quaternion rotation = transform.rotation;
        Vector3 setVector = new Vector3(1, 0, 1);
        setVector = rotation * setVector;

        Vector3 setPosition = transform.position + setVector;

        Instantiate(Trap, setPosition, rotation);
    }

    public override bool NeedsMouseRotation()
    {
        return true;
    }
}
