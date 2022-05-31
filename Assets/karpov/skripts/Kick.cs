using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{

    private State state;
    public float cooldownKick = 5f;
    private float countdownKick = 0;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        state = GetComponent<State>();
    }

    // Update is called once per frame
    void Update()
    {
        reduceCountdownKick();
    }

    public void kickFoot() {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        state.ChangeState(State.States.KICK);
        animator.SetTrigger("Kick");
        countdownKick = cooldownKick;
        Invoke(nameof(reload), 0.65f);
        
    }
    
    public void reload() {
        state.ChangeState(State.States.IDLE);
    }

    public bool checkReadyToKick() {
        return countdownKick <= 0f;
    }

    
    void reduceCountdownKick() {
        if(countdownKick > 0f) {
            countdownKick -= Time.deltaTime;
        }
    }
}
