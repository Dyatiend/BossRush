using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShooting : MonoBehaviour
{

    private PlayerState state;
    public float cooldownFastShooting = 5f;
    private float countdownFastShooting = 0;
    private Animator animator;
    private Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();

        animator = GetComponent<Animator>();

        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        reduceCountdownFastShooting();
    }

    public void FastShoot() {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        state.ChangeState(PlayerState.States.FAST_SHOOT);
        animator.SetTrigger("Fast");
        countdownFastShooting = cooldownFastShooting;
        Invoke(nameof(createBullet), 0.3f);
        Invoke(nameof(createBullet), 0.7f);
        Invoke(nameof(createBullet), 1.1f);
        Invoke(nameof(reload), 1.8f);
    }

    public bool checkReadyToFastShooting() {
        return countdownFastShooting <= 0f;
    }

    void createBullet() {
        shooting.createBullet();
    }

    void reload() {
        shooting.reload();
    }

    void reduceCountdownFastShooting() {
        if(countdownFastShooting > 0f) {
            countdownFastShooting -= Time.deltaTime;
        }
    }
}
