using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPeepob : MonoBehaviour
{
    public GameObject camera; 
    public Transform laser;   
    private PlayerState state;
    private Locomotion locomotion;
    private Shooting shooting;
    private FastShooting fastShooting;
    private ThrowingGrenade throwingGrenade;
    private Dash dash;
    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<PlayerState>();
        locomotion = GetComponent<Locomotion>();
        dash = GetComponent<Dash>();
        fastShooting = GetComponent<FastShooting>();
        throwingGrenade = GetComponent<ThrowingGrenade>();
        shooting = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && state.checkState(PlayerState.States.IDLING))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), camera);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && state.checkState(PlayerState.States.IDLING))
        {
            RotateChar();
            shooting.Shoot();
        }
        if(Input.GetKeyDown(KeyCode.E) && fastShooting.checkReadyToFastShooting() && state.checkState(PlayerState.States.IDLING)) {
            RotateChar();
            fastShooting.FastShoot();
        }
        if(Input.GetKeyDown(KeyCode.Q) && throwingGrenade.checkReadyToThrowingGrenade() && state.checkState(PlayerState.States.IDLING)) {
            RotateChar();
            throwingGrenade.ThrowGrenade();
        }
        if(Input.GetKey(KeyCode.F) && state.checkState(PlayerState.States.IDLING)) {
            RotateChar();
            dash.toDash();
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
