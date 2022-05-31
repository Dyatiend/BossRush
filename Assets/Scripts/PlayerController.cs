using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    
    private State state;
    private Locomotion locomotion;
    private Dictionary<Skill.SkillType, Skill> skills = new Dictionary<Skill.SkillType, Skill>();

    void Start()
    {
        state = GetComponent<State>();
        locomotion = GetComponent<Locomotion>();
        Skill[] addedSkills = GetComponents<Skill>();
        foreach (Skill skill in addedSkills)
        {
            if (!skills.ContainsKey(skill.Type()))
            {
                skills.Add(skill.Type(), skill);
            }
            else
            {
                throw new ConstraintException("Attempting to create a character with multiple skills of the same type");
            }
        }
    }

    private Dictionary<KeyCode, Skill.SkillType> keyBindings = new Dictionary<KeyCode, Skill.SkillType>()
    {
        { KeyCode.Mouse0, Skill.SkillType.Attack },
        { KeyCode.E, Skill.SkillType.Ability },
        { KeyCode.R, Skill.SkillType.Ultimate }
    };
    
    private void Update()
    {
        foreach (KeyValuePair<KeyCode,Skill.SkillType> binding in keyBindings)
        {
            if (Input.GetKeyDown(binding.Key) && (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
            {
                Skill boundSkill = skills[binding.Value];
                if (boundSkill.NeedsMouseRotation())
                {
                    RotateToMousePointerRay();
                }
                boundSkill.Perform();
            }
        }
    }

    void FixedUpdate()
    {
        if ((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && 
            (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
    }

    private void RotateToMousePointerRay()
    {
        Ray look = MousePointerRay();
        transform.rotation = Quaternion.LookRotation(look.direction, Vector3.up);
        Debug.DrawRay(look.origin, look.direction);
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
}
