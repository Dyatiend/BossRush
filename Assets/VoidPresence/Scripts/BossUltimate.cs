using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUltimate : MonoBehaviour
{
    private Animator animator;
    private PlayerState state;

    public GameObject ultimateEffect;

    public float timeBeforeAttack;
    public float timeBetweenAttacks;

    public float ultimateRange;
    public int effectsCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
    }

    public void MakeUltimate()
    {
        state.ChangeState(PlayerState.States.ULTIMATE);

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Ultimate");

        Invoke(nameof(Reload), timeBetweenAttacks);
        Invoke(nameof(CreateUltimateEffects), timeBeforeAttack);
    }

    public void Reload()
    {
        state.ChangeState(PlayerState.States.IDLE);
    }

    public void CreateUltimateEffects()
    {
        for (int i = 0; i < effectsCount; ++i) {
            float randomZ = Random.Range(-ultimateRange, ultimateRange);
            float randomX = Random.Range(-ultimateRange, ultimateRange);

            Vector3 ultimatePoint = new Vector3(transform.position.x + randomX, 0.05f, transform.position.z + randomZ);
            
            Instantiate(ultimateEffect, ultimatePoint, transform.rotation);
        }
    }
}
