using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttack : MonoBehaviour
{
    private Animator animator;
    private State state;

    // Кд
    public float AttackCoolDown;
    private float AttackCoolDown2;
    private bool canAttack;

    public float timeBetweenAttacks;

    //След от удара
    public GameObject slash;

    public AudioSource attackSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        slash.SetActive(false);
        AttackCoolDown2 = AttackCoolDown;
        canAttack = false;
    }

    void Update()
    {
        countCooldown();
    }

    public void Attack()
    {
        canAttack = false;
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

    public bool canAttack_()
    {
        return canAttack;
    }

    IEnumerator slashMove()
    {
        yield return new WaitForSeconds(0.6f);
        slash.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        slash.SetActive(false);
    }

    private void countCooldown()
    {
        if (!canAttack)
        {
            AttackCoolDown2 -= Time.deltaTime;
            if (AttackCoolDown2 < 0)
            {
                canAttack = true;
                AttackCoolDown2 = AttackCoolDown;
            }
        }
    }
}
