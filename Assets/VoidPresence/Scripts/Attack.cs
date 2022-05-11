using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private State state;

    public GameObject projectile;
    public Transform projectilePoint;

    public float timeBeforeAttack;
    public float timeBetweenAttacks;

    public float minAttackRange;
    public float maxAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    public void MakeAttack()
    {
        state.ChangeState(State.States.ATTACK);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Attack");
        
        Invoke(nameof(Reload), timeBetweenAttacks);
        Invoke(nameof(CreateProjectiles), timeBeforeAttack);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }

    public void CreateProjectiles()
    {
        float right = Random.Range(minAttackRange, maxAttackRange);
        float left = -Random.Range(minAttackRange, maxAttackRange);
        Instantiate(projectile, projectilePoint.position, projectilePoint.rotation);
        Instantiate(projectile, projectilePoint.position, Quaternion.Euler(projectilePoint.rotation.eulerAngles + new Vector3(0, right, 0)));
        Instantiate(projectile, projectilePoint.position, Quaternion.Euler(projectilePoint.rotation.eulerAngles + new Vector3(0, left, 0)));
    }
}
