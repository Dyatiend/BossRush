using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VoidBossController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rigidbody;
    private State state;
    private Attack attack;
    private Ability ability;
    private BossUltimate ultimate;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        state = GetComponent<State>();
        attack = GetComponent<Attack>();
        ability = GetComponent<Ability>();
        ultimate = GetComponent<BossUltimate>();
    }

    void Update()
    {
        if(state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN))
        {
            if (Vector3.Distance(transform.position, target.position) >= 15)
            {
                agent.SetDestination(target.position);
                animator.SetFloat("Velocity", rigidbody.velocity.magnitude * 3);
            }
            else if (Vector3.Distance(transform.position, target.position) >= 10f)
            {
                agent.SetDestination(transform.position);
                transform.LookAt(target.position);
                attack.MakeAttack();
            }
            else if (Vector3.Distance(transform.position, target.position) >= 5f)
            {
                agent.SetDestination(transform.position);
                transform.LookAt(target.position);
                ability.MakeAbility();
            }
            else
            {
                agent.SetDestination(transform.position);
                transform.LookAt(target.position);
                ultimate.MakeUltimate();
            }
        }
        
    }
}
