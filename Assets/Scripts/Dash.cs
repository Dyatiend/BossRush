using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody rigidbody;
    private PlayerState state;

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

    }

    public void toDash() {
        state.changeState(PlayerState.States.DASH);
        rigidbody.velocity = Vector3.zero;

        rigidbody.velocity = transform.forward * dashForce;
        Invoke(nameof(endDash), 0.2f);
    }

    void endDash() {
        rigidbody.velocity = Vector3.zero;
        state.changeState(PlayerState.States.IDLING);
    }
}
