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
        return delay;
    }

    protected override float ActiveTime()
    {
        return 2.0f;
    }

    protected override float ReloadTime()
    {
        return 0;
    }

    protected override void Action()
    {
        GameObject obj = Instantiate(jija, jija_point.position, Quaternion.LookRotation(transform.forward));
        obj.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
        obj.GetComponent<Rigidbody>().velocity = transform.forward * speed_forward + transform.up * speed_up;
    }

    public GameObject jija;
    public Transform jija_point;
    public float speed_up;
    public float speed_forward;
    public float delay;
}
