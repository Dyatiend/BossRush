using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody rigidbody;
    private PlayerState state;
    public Transform laser;

    public int dashForce;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        toDash();
    }

    void toDash() {
        if(Input.GetKey(KeyCode.F) && state.checkState(PlayerState.States.IDLING)) {
            state.changeState(PlayerState.States.DASH);
            rigidbody.velocity = Vector3.zero;
            RotateChar();
            rigidbody.velocity = transform.forward * dashForce;
            Invoke(nameof(endDash), 0.2f);
        }
    }

    void endDash() {
        rigidbody.velocity = Vector3.zero;
        state.changeState(PlayerState.States.IDLING);
    }

    public void RotateChar() {
        Vector3 forward = laser.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }
}
