using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthPoints = 100;
    public float deathTime = 2f;

    private Animator animator;
    private PlayerState state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Invoke(nameof(Destroy), .5f);

    }

    private void Destroy()
    {
        animator.SetTrigger("Death");
        state.ChangeState(PlayerState.States.DEAD);
        Destroy(gameObject, deathTime);
    }
}
