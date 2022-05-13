using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum States {
        IDLE,
        RUN,
        ATTACK,
        ABILITY,
        ULTIMATE,
        DEAD,
        STUN,
        DASH,
        THROW,
        FAST_SHOOT,
    }//SHOOT,

    private States state;

    public void ChangeState(States state) {
        if(this.state != States.DEAD && this.state != States.STUN) this.state = state;
    }

    public void UndoStun()
    {
        if (state == States.STUN) state = States.IDLE;
    }

    public States GetState() {
        return this.state;
    }

    public bool CheckState(States state) {
        return GetState() == state;
    }

    void Start()
    {
        ChangeState(States.IDLE);
    }
}
