using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera; 
    public Transform poiter;
    private PlayerState state;
    private Locomotion locomotion;
    private Attack attack;
    private Ability ability;
    private PlayerUltimate ultimate;

    void Start()
    {
        state = GetComponent<PlayerState>();
        locomotion = GetComponent<Locomotion>();
        attack = GetComponent<Attack>();
        ability = GetComponent<Ability>();
        ultimate = GetComponent<PlayerUltimate>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (state.CheckState(PlayerState.States.IDLE) || state.CheckState(PlayerState.States.RUN)))
        {
            RotateToPointer();
            attack.MakeAttack();
        }
        if (Input.GetKeyDown(KeyCode.E) && (state.CheckState(PlayerState.States.IDLE) || state.CheckState(PlayerState.States.RUN)))
        {
            RotateToPointer();
            ability.MakeAbility();
        }
        if (Input.GetKeyDown(KeyCode.R) && (state.CheckState(PlayerState.States.IDLE) || state.CheckState(PlayerState.States.RUN)))
        {
            RotateToPointer();
            ultimate.MakeUltimate();
        }
    }

    void FixedUpdate()
    {
        if ((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && 
            (state.CheckState(PlayerState.States.IDLE) || state.CheckState(PlayerState.States.RUN)))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), camera);
        }
    }

    public void RotateToPointer()
    {
        Vector3 forward = poiter.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }
}
