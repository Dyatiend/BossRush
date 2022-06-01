using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowKarpovGranade : MonoBehaviour
{
    private Animator animator;
    public Transform grenadePoint;
    public GameObject grenadePrefab;
    private State state;
    public float cooldownThrowingGrenade = 10f;
    private float countdownThrowingGrenade = 0;
    public float throwForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        state = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        reduceCountdownThrowingGrenade();
    }

    public void ThrowGrenade() {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        state.ChangeState(State.States.THROW);
        countdownThrowingGrenade = cooldownThrowingGrenade;
        animator.SetTrigger("Throw");
        Invoke(nameof(createGrenade), 0.3f);
        Invoke(nameof(reload), 0.65f);
    }

    public void reload() {
        state.ChangeState(State.States.IDLE);
    }

    public bool checkReadyToThrowingGrenade() {
        return countdownThrowingGrenade <= 0f;
    }

    void createGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, grenadePoint.position, grenadePoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(grenadePoint.transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void reduceCountdownThrowingGrenade() {
        if(countdownThrowingGrenade > 0f) {
            countdownThrowingGrenade -= Time.deltaTime;
        }
    }
}