using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    private Animator animator;
    private State state;

    public float timeBetweenAttacks;

    //----- След от удара
    public GameObject slash;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        slash.SetActive(false);
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        animator.SetTrigger("SimpleAttack");
        StartCoroutine(slashMove());

        state.ChangeState(State.States.ATTACK);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);

        Invoke(nameof(Reload), timeBetweenAttacks);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }

    IEnumerator slashMove()
    {
        yield return new WaitForSeconds(0.6f);
        slash.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        slash.SetActive(false);
    }
}
