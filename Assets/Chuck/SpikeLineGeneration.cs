using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLineGeneration : MonoBehaviour
{
    public int numberOfSpikesToSet;
    public Rigidbody Trap;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(NextGeneration), 0.4f);
        Destroy(gameObject, 3.4f);
    }

    void NextGeneration()
    {
        if (numberOfSpikesToSet > 0)
        {
            Quaternion rotation = transform.rotation;
            Vector3 setVector = new Vector3(1, 0, 1);
            setVector = rotation * setVector;

            Vector3 setPosition = transform.position + setVector;

            Rigidbody newRigid = Instantiate(Trap, setPosition, rotation);
            newRigid.gameObject.GetComponent<SpikeLineGeneration>().Trap = Trap;
            newRigid.gameObject.GetComponent<SpikeLineGeneration>().numberOfSpikesToSet = numberOfSpikesToSet - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
