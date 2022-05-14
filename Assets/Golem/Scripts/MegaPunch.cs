using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaPunch : MonoBehaviour
{
    private Animator animator;
    private State state;

    public float timeBetweenAttacks;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    
    void Update()
    {
        
    }

    public void Attack()
    {
        animator.SetTrigger("MegaPunch");

        state.ChangeState(State.States.ULTIMATE);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);



        Invoke(nameof(Reload), timeBetweenAttacks);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }
}
