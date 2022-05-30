using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    private Animator animator;
    
    private State state;
    private Locomotion locomotion;
    private Dictionary<Skill.SkillType, Skill> skills = new Dictionary<Skill.SkillType, Skill>();
    private Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
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
        
        nextDecisionTime = Time.time;
    }


    private float nextDecisionTime;
    private void Update()
    {
        if (!agent.isStopped)
        {
            GetComponent<Rigidbody>().velocity = agent.velocity;
        }
        animator.SetFloat("Velocity", agent.velocity.magnitude/agent.speed);
        
        if (Time.time < nextDecisionTime)
        {
            return;
        }
        
        List<Skill> available = new List<Skill>();
        foreach (Skill skill in skills.Values)
        {
            if (skill.BossUseConditions())
            {
                available.Add(skill);
            }
        }
        //print(available.Count);

        if (available.Count == 0 || Random.value < 0.3f)
        {
            agent.isStopped = false;
        }
        else
        {
            agent.isStopped = true;
            //agent.SetDestination(transform.position);
            Skill performing = available[Random.Range(0, available.Count)];
            if (performing.NeedsMouseRotation())
            {
                transform.LookAt(target.position);
            }
            performing.Perform();
        }
        nextDecisionTime = Time.time + 4f;
    }

    void FixedUpdate()
    {
        agent.SetDestination(target.position);
        transform.LookAt(agent.destination);
        /*if ((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && 
            (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }*/
    }
}
