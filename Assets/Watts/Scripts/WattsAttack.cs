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
        return true;
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
        float arkRadius = 1f;
        float startAngle = -50f;
        
        Vector3 origin = gameObject.transform.position + Vector3.up * 1.2f + transform.TransformDirection(Vector3.forward) * 0.5f;
        GameObject slash = Instantiate(slashCollider, origin + transform.TransformDirection(SphericalToCartesian(arkRadius, Mathf.Deg2Rad * startAngle, 0)), Quaternion.LookRotation(transform.TransformDirection(SphericalToCartesian(arkRadius, Mathf.Deg2Rad * startAngle, 0))));
        SlashRotate r = slash.GetComponent<SlashRotate>();
        r.pivot = origin;
        slash.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
        slash.GetComponent<ObjectLifetime>().destroyAfter = r.duration;
    }
    
    public static Vector3 SphericalToCartesian(float radius, float polar, float elevation){
        Vector3 outCart = Vector3.zero;
        float a = radius * Mathf.Cos(elevation);
        outCart.x = a * Mathf.Cos(polar);
        outCart.y = radius * Mathf.Sin(elevation);
        outCart.z = a * Mathf.Sin(polar);
        return outCart;
    }

    public override bool BossUseConditions()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        return base.BossUseConditions() && Vector3.Distance(transform.position, target.position) < 3;
    }
}
