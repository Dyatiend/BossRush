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
        return 1.2f;
    }

    protected override float ActiveTime()
    {
        return 1.1f;
    }

    protected override void Action()
    {
        Quaternion rotation = gameObject.transform.rotation;
        Vector3 setVector = new Vector3(0, 0, 1);
        setVector = rotation * setVector;

        Vector3 setPosition = gameObject.transform.position + setVector;

        Transform spike = Instantiate(Trap, setPosition, rotation);
        spike.gameObject.AddComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
    }

    public override bool NeedsMouseRotation()
    {
        return true;
    }

    public override bool BossUseConditions()
    {
        bool isReload = base.BossUseConditions();

        if (isReload)
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            if (Vector3.Distance(playerPosition, gameObject.transform.position) > 9)
            {
                isReload = false;
            }
        }

        return isReload;
    }
}
