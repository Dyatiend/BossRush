using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private PlayerState state;
    
    public float moveSpeed;
    public float rotationSpeed;
    public float walkAnimationSpeed;
    public Vector3 velocity;
    private Rigidbody rigidbody;
    private Animator animator;

    public GameObject camera;    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        state = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) && state.checkState(PlayerState.States.IDLING))
        {
            state.changeState(PlayerState.States.RUNNING);
            float forward = Input.GetAxis("Vertical");
            float right = Input.GetAxis("Horizontal");

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
            state.changeState(PlayerState.States.IDLING);
        }
    }
}
