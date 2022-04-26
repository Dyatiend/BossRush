using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTyan : MonoBehaviour
{
    public GameObject camera; 
    private Locomotion locomotion;
    // Start is called before the first frame update
    void Start()
    {
        locomotion = GetComponent<Locomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f))
        {
            locomotion.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), camera);
        }
    }
}
