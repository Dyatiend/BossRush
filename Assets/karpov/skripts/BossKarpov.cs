using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossKarpov : MonoBehaviour
{
    private NavMeshAgent nashAgent;
    private Transform target;
    private Animator animator;
    private Rigidbody rigidbody;
    private ShootingKarpov shooting;
    private State state;
    private ThrowKarpovGranade throwingGrenade;
    private Locomotion locomotion;
    private Kick kick;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        nashAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        shooting = GetComponent<ShootingKarpov>();
        state = GetComponent<State>();
        throwingGrenade = GetComponent<ThrowKarpovGranade>();
        locomotion = GetComponent<Locomotion>();
        kick = GetComponent<Kick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.CheckState(State.States.IDLE) 
        && Vector3.Distance(transform.position, target.position) <= 15f
        && Vector3.Distance(transform.position, target.position) > 10f
        && throwingGrenade.checkReadyToThrowingGrenade()) {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target.position);
            throwingGrenade.ThrowGrenade();      
        }
        else if(state.CheckState(State.States.IDLE) 
        && Vector3.Distance(transform.position, target.position) >= 10f) {
            nashAgent.SetDestination(target.position);
            animator.SetFloat("Velocity", rigidbody.velocity.magnitude * locomotion.walkAnimationSpeed);
        }
        else if(state.CheckState(State.States.IDLE) 
                && Vector3.Distance(transform.position, target.position) <= 10f) {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target.position);
            shooting.Shoot();       
        }
    }

    private float rotation;

    void rotate() {
        Vector3 v = transform.rotation.eulerAngles;
        v.y -= +15f;
        Quaternion newRotation = Quaternion.Euler(v);
        transform.rotation = newRotation;
    }
}
