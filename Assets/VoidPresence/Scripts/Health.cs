using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints = 100;
    public float deathTime = 2f;

    private Animator animator;
    private State state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Invoke(nameof(Destroy), .5f);

    }

    private void Destroy()
    {
        animator.SetTrigger("Death");
        state.ChangeState(State.States.DEAD);
        Destroy(gameObject, deathTime);
    }
}
