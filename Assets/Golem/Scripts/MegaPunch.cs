using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaPunch : MonoBehaviour
{
    private Animator animator;
    private State state;

    public float timeBetweenAttacks;
    public GameObject tornado;
    public Transform tornadoPoint;
    private AudioSource sound;

    // ‰
    public float UltimateCoolDown;
    private float UltimateCoolDown2;
    private bool canUltimate;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        sound = GetComponent<AudioSource>();
        canUltimate = true;
        UltimateCoolDown2 = UltimateCoolDown;
    }

    
    void Update()
    {
        countCooldown();
    }

    public void Attack()
    {
        canUltimate = false;
        animator.SetTrigger("MegaPunch");

        state.ChangeState(State.States.ULTIMATE);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);

        Invoke(nameof(CreateTornado), 1.8f);
        Invoke(nameof(Reload), timeBetweenAttacks);
        Invoke(nameof(playSound), 1.43f);
    }

    public void Reload()
    {
        state.ChangeState(State.States.IDLE);
    }
    public bool canUltimate_()
    {
        return canUltimate;
    }

    void CreateTornado()
    {
        GameObject fireball = Instantiate(tornado, tornadoPoint.position, Quaternion.Euler(-90, 0, 0));
    }

    void playSound()
    {
        sound.Play();
    }

    private void countCooldown()
    {
        if (!canUltimate)
        {
            UltimateCoolDown2 -= Time.deltaTime;
            if (UltimateCoolDown2 < 0)
            {
                canUltimate = true;
                UltimateCoolDown2 = UltimateCoolDown;
            }
        }
    }

}
