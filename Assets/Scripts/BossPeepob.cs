using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossPeepob : MonoBehaviour
{
    private NavMeshAgent nashAgent;
    private Transform target;
    private Animator animator;
    private Rigidbody rigidbody;
    private Shooting shooting;
    private PlayerState state;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Tyan")[0].transform;
        nashAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        shooting = GetComponent<Shooting>();
        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.checkState(PlayerState.States.IDLING)) {
            nashAgent.SetDestination(target.position);
            animator.SetFloat("Velocity", rigidbody.velocity.magnitude * 3);
        }
        if(state.checkState(PlayerState.States.IDLING) && Vector3.Distance(transform.position, target.position) <= 7f) {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target.position);
            shooting.Shoot();       
        }
    }
}
