using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goo_ultimate : Skill
{
    public override SkillType Type()
    {
        return SkillType.Ultimate;
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
        return 5.8f;
    }

    protected override float ReloadTime()
    {
        return 0;
    }

    protected override void Action()
    {
        Invoke(nameof(katana_setActive),timeActive);
        Invoke(nameof(katana_setNotActive),timeNotActive);
    }

    public GameObject katana;
    public float timeActive = 2f;
    public float timeNotActive = 10f;

    protected void katana_setActive()
    {
        katana.SetActive(true);
        katana.GetComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
    }

    protected void katana_setNotActive()
    {
        katana.SetActive(false);
    }
}
