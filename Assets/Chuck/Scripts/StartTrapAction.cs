using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrapAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Targeting>().ConfigureTargetingAs("Boss");
    }
}
