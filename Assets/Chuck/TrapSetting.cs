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
        return false;
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
        return 1.616f;
    }

    protected override float ActiveTime()
    {
        return 0.0f;
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
        Vector3 setVector = new Vector3(1, 0, 1);
        setVector = rotation * setVector;

        Vector3 setPosition = transform.position + setVector;

        Instantiate(Trap, setPosition, rotation);
    }

    private Ray MousePointerRay()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Ray rotation = new Ray(transform.position, targetPoint - transform.position);
            return rotation;
        }
        else
        {
            return new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        }
    }

    private void RotateToMousePointerRay()
    {
        Ray look = MousePointerRay();
        transform.rotation = Quaternion.LookRotation(look.direction, Vector3.up);
        Debug.DrawRay(look.origin, look.direction);
    }
}
