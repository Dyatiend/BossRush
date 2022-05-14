using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
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
        animator.SetTrigger("SimpleAttack");

        state.ChangeState(State.States.ATTACK);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);

        Invoke(nameof(Reload), timeBetweenAttacks);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }
}
