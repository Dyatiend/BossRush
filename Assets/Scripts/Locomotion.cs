using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Скрипт передвижения (только для игрока)
public class Locomotion : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotationSpeed = 10;
    public float walkAnimationSpeed = 1; // Может быть стоит убрать, т.к. здесь можно только замедлить анимацию, а в AnimatorController и замедлить, и ускорить
    public Vector3 velocity;
    private GameObject camera;

    private Rigidbody rigidbody;
    private Animator animator;
    private State state;

    private float maxMoveSpeed;
	
    void Start()
    {
        camera = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        maxMoveSpeed = moveSpeed;
    }

    public void Move(float forward, float right)
    {
        state.ChangeState(State.States.RUN);

        Vector3 translation = Vector3.zero;

        translation = forward * new Vector3(camera.transform.up.x, 0, camera.transform.up.z).normalized;
        translation += right * new Vector3(camera.transform.right.x, 0, camera.transform.right.z).normalized;
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
	
	// Замедляет на указанное время
	// slowing - замедление от 0 до 1
    public void Slow(float slowing, float time)
    {
        if (maxMoveSpeed == moveSpeed)
        {
            moveSpeed = moveSpeed * slowing;
            Invoke(nameof(UndoSlow), time);
        }
    }

	// Отменяет наложенное замедление
    private void UndoSlow()
    {
        moveSpeed = maxMoveSpeed;
    }

	// Оглушает на указанное время
    public void Stun(float stunTime)
    {
        rigidbody.velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        animator.SetTrigger("Stun");

        state.ChangeState(State.States.STUN);
        Invoke(nameof(UndoStun), stunTime);
    }

	// Снимает оглушение
    private void UndoStun()
    {
        animator.SetTrigger("Unstun");
        state.UndoStun();
    }
}
