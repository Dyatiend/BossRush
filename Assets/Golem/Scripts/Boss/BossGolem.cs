using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossGolem : MonoBehaviour
{
    private NavMeshAgent nashAgent;
    private Transform target;
    private Animator animator;
    private Rigidbody rigidbody;

    private MegaPunch ultimate;
    private State state;
    private SpellAttack ability;
    private SimpleAttack simpleAttack;
    private Locomotion locomotion;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        nashAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        state = GetComponent<State>();    
        locomotion = GetComponent<Locomotion>();
        ultimate = GetComponent<MegaPunch>();
        ability = GetComponent<SpellAttack>();
        simpleAttack = GetComponent<SimpleAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(target.position);
        if (state.CheckState(State.States.IDLE)
        && Vector3.Distance(transform.position, target.position) <= 15f
        && ability.canAbility_())
        {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target.position);
            ability.Attack();
        }
        else if (state.CheckState(State.States.IDLE)
        && Vector3.Distance(transform.position, target.position) < 3f)
        {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target.position);
            simpleAttack.Attack();
        }     
        else if (Vector3.Distance(transform.position, target.position) <= 6f
            && Vector3.Distance(transform.position, target.position) > 3.5f
        && ultimate.canUltimate_() && state.CheckState(State.States.IDLE))
        {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target);
            ultimate.Attack();
        }
        else if (state.CheckState(State.States.IDLE)
        && Vector3.Distance(transform.position, target.position) >= 3f)
        {
            nashAgent.SetDestination(target.position);
            animator.SetFloat("Velocity", rigidbody.velocity.magnitude * locomotion.walkAnimationSpeed);
            Debug.Log(locomotion.walkAnimationSpeed);
        }

    }

}
