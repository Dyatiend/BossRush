using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiskovAttack : Skill
{
    // Start is called before the first frame update
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
        return 1.15f;
    }

    protected override float ActiveTime()
    {
        return 2;
    }

    protected override float ReloadTime()
    {
        return 1;
    }

    public Transform stonePoint;
    public GameObject stone;
    public float stoneSpeed = 25;
    protected override void Action()
    {
        GameObject stoneThrow = Instantiate(stone, stonePoint.position,
            Quaternion.LookRotation(transform.TransformDirection(Vector3.forward)));
        stoneThrow.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
        stoneThrow.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * stoneSpeed;
    }
}
