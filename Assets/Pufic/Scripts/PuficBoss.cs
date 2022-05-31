using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuficBoss : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rigidbody;
    private State state;
    private AttackPufic attack;
    private ThrowTrap ability;
    private ComboAttack ultimate;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        state = GetComponent<State>();
        attack = GetComponent<AttackPufic>();
        ability = GetComponent<ThrowTrap>();
        ultimate = GetComponent<ComboAttack>();

        //agent.enabled = false;
    }

    void Update()
    {
        if ((state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)) && agent.enabled)
        {
            if (Vector3.Distance(transform.position, target.position) >= 8)
            {
                agent.SetDestination(target.position);
                animator.SetFloat("Velocity", rigidbody.velocity.magnitude * 3);
            }
            else if (Vector3.Distance(transform.position, target.position) >= 5f)
            {
                agent.SetDestination(transform.position);
                transform.LookAt(target.position);
                ultimate.Perform();
            }
            else if (Vector3.Distance(transform.position, target.position) >= 1f && ability.BossUseConditions())
            {
                agent.SetDestination(transform.position);
                transform.LookAt(target.position);
                ability.Perform();
            }
            else if (Vector3.Distance(transform.position, target.position) <= 1f)
            {
                agent.SetDestination(transform.position);
                transform.LookAt(target.position);
                attack.Perform();
            }
            else
            {
                agent.SetDestination(target.position);
                animator.SetFloat("Velocity", rigidbody.velocity.magnitude * 3);
            }
        }

    }
}