using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float walkAnimationSpeed;
    public Vector3 velocity;
    public GameObject camera;

    private Rigidbody rigidbody;
    private Animator animator;
    private State state;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

    public void Move(float forward, float right)
    {
        state.ChangeState(State.States.RUN);

        Vector3 translation = Vector3.zero;

        translation = forward * camera.transform.forward;
        translation += right * camera.transform.right;
        translation.y = 0;

        if(translation.magnitude > 0.2f)
        {
            velocity = translation;
        }
        else
        {
            velocity = Vector3.zero;
        }

        rigidbody.velocity = new Vector3(velocity.normalized.x * moveSpeed, rigidbody.velocity.y, velocity.normalized.z * moveSpeed);

        if (velocity.magnitude > 0.2f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(velocity), Time.deltaTime * rotationSpeed);
        }

        animator.SetFloat("Velocity", velocity.magnitude * walkAnimationSpeed);

        state.ChangeState(State.States.IDLE);
    }

    private float previousMoveSpeed;

    public void Slow(float slowing, float time)
    {
        previousMoveSpeed = moveSpeed;
        moveSpeed = moveSpeed * slowing;
        Invoke(nameof(UndoSlow), time);
    }

    private void UndoSlow()
    {
        moveSpeed = previousMoveSpeed;
    }

    public void Stun(float stunTime)
    {
        rigidbody.velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);

        state.ChangeState(State.States.STUN);
        Invoke(nameof(UndoStun), stunTime);
    }

    private void UndoStun()
    {
        state.UndoStun();
    }
}
