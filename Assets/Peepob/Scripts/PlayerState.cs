using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum States {
        IDLING,
        RUNNING,
        DASH,
        SHOOTING,
        THROWING,
        FAST_SHOOTING   
    }

    private States state;

    public void changeState(States state) {
        this.state = state;
    }

    public States getState() {
        return this.state;
    }

    public bool checkState(States state) {
        return getState() == state;
    }

    // Start is called before the first frame update
    void Start()
    {
        changeState(States.IDLING);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
