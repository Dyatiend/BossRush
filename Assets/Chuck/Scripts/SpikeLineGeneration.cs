using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeLineGeneration : MonoBehaviour
{
    public int numberOfSpikesToSet;
    //public Transform Trap;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(NextGeneration), 0.2f);
        Destroy(gameObject, 3.4f);
    }

    void NextGeneration()
    {
        if (numberOfSpikesToSet > 0)
        {
            Quaternion rotation = transform.rotation;
            Vector3 setVector = new Vector3(0, 0, 1);
            setVector = rotation * setVector;

            Vector3 setPosition = transform.position + setVector;

            Transform spike = Instantiate(GetComponent<Transform>(), setPosition, rotation);
            print(GetComponent<Targeting>().OwnerTag);
            //spike.gameObject.AddComponent<Targeting>().ConfigureTargetingAs(GetComponent<Targeting>().OwnerTag);
            spike.gameObject.GetComponent<Targeting>().ConfigureTargetingAs(GetComponent<Targeting>().OwnerTag);
            SpikeLineGeneration generation = spike.gameObject.GetComponent<SpikeLineGeneration>();
            //generation.Trap = Trap;
            generation.numberOfSpikesToSet = numberOfSpikesToSet - 1;
            //print(GetComponent<Targeting>().OwnerTag);

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
