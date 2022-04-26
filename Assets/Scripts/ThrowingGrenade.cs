using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingGrenade : MonoBehaviour
{
    private Animator animator;
    public Transform laser;
    public Transform grenadePoint;
    public GameObject grenadePrefab;
    private PlayerState state;
    public float cooldownThrowingGrenade = 10f;
    private float countdownThrowingGrenade = 0;
    private bool readyToThrowingGrenade = true;
    public float throwForce = 10f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowGrenade();
        reduceCountdownThrowingGrenade();
    }

    void ThrowGrenade() {
        if(Input.GetKeyDown(KeyCode.Q) && readyToThrowingGrenade && state.checkState(PlayerState.States.IDLING)) {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            animator.SetFloat("Velocity", 0);
            state.changeState(PlayerState.States.THROWING);
            RotateChar();
            countdownThrowingGrenade = cooldownThrowingGrenade;
            readyToThrowingGrenade = false;
            animator.SetTrigger("Throw");
            Invoke(nameof(createGrenade), 0.3f);
        }
    }

    void createGrenade() {
        GameObject grenade = Instantiate(grenadePrefab, grenadePoint.position, grenadePoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(grenadePoint.transform.forward * throwForce, ForceMode.VelocityChange);
        state.changeState(PlayerState.States.IDLING);
    }

    void RotateChar() {
        Vector3 forward = laser.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }

    void reduceCountdownThrowingGrenade() {
        countdownThrowingGrenade -= Time.deltaTime;
        if(countdownThrowingGrenade <= 0f && !readyToThrowingGrenade) {
            readyToThrowingGrenade = true;
        }
    }
}
