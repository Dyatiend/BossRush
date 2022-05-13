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
    private FastShooting fastShooting;
    private ThrowingGrenade throwingGrenade;
    private Locomotion locomotion;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        nashAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        shooting = GetComponent<Shooting>();
        state = GetComponent<PlayerState>();
        fastShooting = GetComponent<FastShooting>();
        throwingGrenade = GetComponent<ThrowingGrenade>();
        locomotion = GetComponent<Locomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state.CheckState(PlayerState.States.IDLE) 
        && Vector3.Distance(transform.position, target.position) <= 15f
        && Vector3.Distance(transform.position, target.position) > 10f
        && throwingGrenade.checkReadyToThrowingGrenade()) {
            nashAgent.SetDestination(transform.position);
            transform.LookAt(target.position);
            throwingGrenade.ThrowGrenade();       
        }
        else if(state.CheckState(PlayerState.States.IDLE) 
        && Vector3.Distance(transform.position, target.position) >= 10f) {
            nashAgent.SetDestination(target.position);
            animator.SetFloat("Velocity", rigidbody.velocity.magnitude * locomotion.walkAnimationSpeed);
        }
        else if(Vector3.Distance(transform.position, target.position) <= 5f 
        && fastShooting.checkReadyToFastShooting() && state.CheckState(PlayerState.States.IDLE)) {
            nashAgent.SetDestination(transform.position);

            transform.LookAt(target);
            
            Vector3 v = transform.rotation.eulerAngles;
            v.y -= -30f;
            Quaternion newRotation = Quaternion.Euler(v);
            transform.rotation = newRotation;
            fastShooting.FastShoot();
            Invoke(nameof(rotate), 0.25f);
            Invoke(nameof(rotate), 0.65f);
            Invoke(nameof(rotate), 1.05f);            
        }
        else if(state.CheckState(PlayerState.States.IDLE) 
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
