using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    private Animator animator;
    private State state;

    public GameObject ability;
    public Transform abilityPoint;

    public float timeBeforeAttack;
    public float timeBetweenAttacks;

    public float minAttackRange = -180;
    public float maxAttackRange = 180;

    public int attackCount = 100;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    public void MakeAbility()
    {
        state.ChangeState(State.States.ABILITY);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Ability");

        Invoke(nameof(Reload), timeBetweenAttacks);
        Invoke(nameof(CreateAbilityEffect), timeBeforeAttack);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }

    public void CreateAbilityEffect()
    {
        for (int i = 0; i < attackCount; ++i)
        {
            float rot = Random.Range(minAttackRange, maxAttackRange);
            Instantiate(ability, abilityPoint.position, Quaternion.Euler(abilityPoint.rotation.eulerAngles + new Vector3(0, rot, 0)));
        }
    }
}
