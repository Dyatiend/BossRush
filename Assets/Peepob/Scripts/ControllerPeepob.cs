using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPeepob : MonoBehaviour
{
    public Transform laser;   
    private State state;
    private Locomotion locomotion;
    private Shooting shooting;
    private FastShooting fastShooting;
    private ThrowingGrenade throwingGrenade;
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<State>();
        locomotion = GetComponent<Locomotion>();
        fastShooting = GetComponent<FastShooting>();
        throwingGrenade = GetComponent<ThrowingGrenade>();
        shooting = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && state.CheckState(State.States.IDLE))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && state.CheckState(State.States.IDLE))
        {
            RotateChar();
            shooting.Shoot();
        }
        if(Input.GetKeyDown(KeyCode.E) && fastShooting.checkReadyToFastShooting() && state.CheckState(State.States.IDLE)) {
            RotateChar();
            fastShooting.FastShoot();
        }
        if(Input.GetKeyDown(KeyCode.Q) && throwingGrenade.checkReadyToThrowingGrenade() && state.CheckState(State.States.IDLE)) {
            RotateChar();
            throwingGrenade.ThrowGrenade();
        }
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
