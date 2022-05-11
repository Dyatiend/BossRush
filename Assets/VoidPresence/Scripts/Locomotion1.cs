using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion1 : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float walkAnimationSpeed;
    public Vector3 velocity;
    public GameObject camera;

    private Rigidbody rigidbody;
    private Animator animator;
    private State state;

    private float maxMoveSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        maxMoveSpeed = moveSpeed;
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

    

    public void Slow(float slowing, float time)
    {
        if (maxMoveSpeed == moveSpeed)
        {
            moveSpeed = moveSpeed * slowing;
            Invoke(nameof(UndoSlow), time);
        }
    }

    private void UndoSlow()
    {
        moveSpeed = maxMoveSpeed;
    }

    public void Stun(float stunTime)
    {
        rigidbody.velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Stun");

        state.ChangeState(State.States.STUN);
        Invoke(nameof(UndoStun), stunTime);
    }

    private void UndoStun()
    {
        animator.SetTrigger("Unstun");
        state.UndoStun();
    }
}
