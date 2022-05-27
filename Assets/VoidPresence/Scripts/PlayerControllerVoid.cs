using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerVoid : MonoBehaviour
{
    public Transform poiter;
    private State state;
    private Locomotion locomotion;
    private Attack attack;
    private Ability ability;
    private PlayerUltimate ultimate;

    void Start()
    {
        state = GetComponent<State>();
        locomotion = GetComponent<Locomotion>();
        attack = GetComponent<Attack>();
        ability = GetComponent<Ability>();
        ultimate = GetComponent<PlayerUltimate>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            RotateToPointer();
            attack.MakeAttack();
        }
        if (Input.GetKeyDown(KeyCode.E) && (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            RotateToPointer();
            ability.MakeAbility();
        }
        if (Input.GetKeyDown(KeyCode.R) && (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            RotateToPointer();
            ultimate.MakeUltimate();
        }
    }

    void FixedUpdate()
    {
        if ((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && 
            (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
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
