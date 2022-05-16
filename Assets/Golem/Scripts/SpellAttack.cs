using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAttack : MonoBehaviour
{
    private Animator animator;

    public GameObject projectile;
    public Transform projectilePoint;
    
    public float timeBetweenAttacks;
    private State state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
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

    private void setAnimation()
    {
        animator.SetTrigger("Spell");
    }
}
