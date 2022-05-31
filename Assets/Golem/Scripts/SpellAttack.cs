using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    private Animator animator;

    public GameObject projectile;
    public Transform projectilePoint;

    // ‰
    public float AbilityCoolDown;
    private float AbilityCoolDown2;
    private bool canAbility;

    public float timeBetweenAttacks;
    private State state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        canAbility = true;
        AbilityCoolDown2 = AbilityCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        countCooldown();
    }

    public void Attack()
    {
        canAbility = false;
        Invoke(nameof(setAnimation), 0.7f);
        
        state.ChangeState(State.States.ABILITY);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);

        CreateFireball();
        Invoke(nameof(Reload), timeBetweenAttacks);
    }

    void CreateFireball()
    {
        GameObject fireball = Instantiate(projectile, projectilePoint.position, projectilePoint.rotation);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }

    public bool canAbility_()
    {
        return canAbility;
    }
    private void setAnimation()
    {
        animator.SetTrigger("Spell");
    }

    private void countCooldown()
    {
        if (!canAbility)
        {
            AbilityCoolDown2 -= Time.deltaTime;
            if (AbilityCoolDown2 < 0)
            {
                canAbility = true;
                AbilityCoolDown2 = AbilityCoolDown;
            }
        }
    }
}
