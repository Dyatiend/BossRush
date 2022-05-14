using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float walkAnimationSpeed;
    public Vector3 velocity;
    private State state;

    private Rigidbody rigidbody;
    private Animator animator;
    private Locomotion locomotion;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        locomotion = GetComponent<Locomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) &&
            (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }
    }

    void FixedUpdate()
    {
        
    }
}
