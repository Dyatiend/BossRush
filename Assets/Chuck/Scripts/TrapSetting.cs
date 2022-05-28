using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSetting : Skill
{
    public Transform Trap;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    override public bool NeedsMouseRotation()
    {
        return true;
    }

    override protected float ReloadTime()
    {
        return 5.0f;
    }

    public override SkillType Type()
    {
        return SkillType.Ability;
    }

    protected override float HoldUpTime()
    {
        return 0.6f;
    }

    protected override float ActiveTime()
    {
        //return 0.416f;
        return 0;
    }

    protected override void Action()
    {
        //if (gameObject.tag == "Player")
        //{
            //Ray mouseRay = MousePointerRay();
            //RotateToMousePointerRay();
        //}

        //GetComponent<PlayerController>().MousePointerRay();
        Quaternion rotation = transform.rotation;
        Vector3 setVector = new Vector3(0, 0, 1);
        setVector = rotation * setVector;

        Vector3 setPosition = transform.position + setVector;

        Transform spike = Instantiate(Trap, setPosition, rotation);
        spike.gameObject.AddComponent<Targeting>().ConfigureTargetingAs(gameObject.tag);
    }
}
