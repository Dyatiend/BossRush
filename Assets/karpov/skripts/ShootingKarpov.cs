using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingKarpov : MonoBehaviour
{
    private Animator animator;
    private State state;
    public Transform bullet;
    public Transform shotPoint;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        state = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Shot");
        state.ChangeState(State.States.ATTACK);
        Invoke(nameof(reload), 1.15f);
        Invoke(nameof(createBullet), 0.3f);
    }

    public void reload()
    {
        state.ChangeState(State.States.IDLE);
    }

    public void createBullet()
    {
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
    }
}
