using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShooting : MonoBehaviour
{

    private PlayerState state;
    public float cooldownFastShooting = 5f;
    private float countdownFastShooting = 0;
    private bool readyToFastShooting = true;
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
        FastShoot();
        reduceCountdownFastShooting();
    }

    void FastShoot() {
        if(Input.GetKeyDown(KeyCode.E) && readyToFastShooting && state.checkState(PlayerState.States.IDLING)) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            animator.SetFloat("Velocity", 0);
            state.changeState(PlayerState.States.FAST_SHOOTING);
            animator.SetTrigger("Fast");
            shooting.RotateChar();
            countdownFastShooting = cooldownFastShooting;
            readyToFastShooting = false;
            Invoke(nameof(createBullet), 0.3f);
            Invoke(nameof(createBullet), 0.7f);
            Invoke(nameof(createBullet), 1.1f);
            Invoke(nameof(reload), 1.2f);
        }
    }

    void createBullet() {
        shooting.createBullet();
    }

    void reload() {
        shooting.reload();
    }

    void reduceCountdownFastShooting() {
        countdownFastShooting -= Time.deltaTime;
        if(countdownFastShooting <= 0f && !readyToFastShooting) {
            readyToFastShooting = true;
        }
    }
}
