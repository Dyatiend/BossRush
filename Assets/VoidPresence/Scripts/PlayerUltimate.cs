using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    private Animator animator;
    private State state;

    public GameObject ultimateEffect;
    public Transform ultimatePoint;

    public float timeBeforeAttack;
    public float timeBetweenAttacks;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    public void MakeUltimate()
    {
        state.ChangeState(State.States.ULTIMATE);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Ultimate");

        Invoke(nameof(Reload), timeBetweenAttacks);
        Invoke(nameof(CreateUltimateEffect), timeBeforeAttack);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }

    public void CreateUltimateEffect()
    {
        Instantiate(ultimateEffect, ultimatePoint.position, ultimatePoint.rotation);
    }
}