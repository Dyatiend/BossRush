using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public enum States
    {
        IDLE,
        RUN,
        ATTACK,
        ABILITY,
        ULTIMATE,
        DEAD,
        STUN
    }

    private States state;

    public void ChangeState(States state)
    {
        if(this.state != States.DEAD && this.state != States.STUN) this.state = state;
    }

    public void UndoStun()
    {
        if (state == States.STUN) state = States.IDLE;
    }

    public States GetState()
    {
        return this.state;
    }

    public bool CheckState(States state)
    {
        return GetState() == state;
    }
    void Start()
    {
        ChangeState(States.IDLE);
    }
}
