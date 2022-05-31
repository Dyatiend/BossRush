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

    private MegaPunch ultimate;
    private SpellAttack ability;
    private SimpleAttack simpleAttack;

    public Transform laser;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        locomotion = GetComponent<Locomotion>();
        ultimate = GetComponent<MegaPunch>();
        ability = GetComponent<SpellAttack>();
        simpleAttack = GetComponent<SimpleAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f) &&
            (state.CheckState(State.States.IDLE) || state.CheckState(State.States.RUN)))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        }

        if (Input.GetMouseButtonDown(0) && simpleAttack.canAttack_())
        {
            RotateChar();
            if (state.CheckState(State.States.IDLE))
            {
                simpleAttack.Attack();
            }           
        }
        if (Input.GetKeyDown(KeyCode.Q) && ultimate.canUltimate_())
        {
            RotateChar();
            if (state.CheckState(State.States.IDLE))
            {
                ultimate.Attack();
            }
                
        }
        if (Input.GetKeyDown(KeyCode.E) && ability.canAbility_())
        {
            RotateChar();
            if (state.CheckState(State.States.IDLE))
            {
                ability.Attack();
            }          
        }
    }

    public void RotateChar()
    {
        Vector3 forward = laser.transform.position - transform.position;
        Vector3 upward = Vector3.up;

        Quaternion newRotation = Quaternion.LookRotation(forward, upward);
        newRotation.z = 0.0f;
        newRotation.x = 0.0f;
        transform.rotation = newRotation;
    }

    void FixedUpdate()
    {
        
    }
}
