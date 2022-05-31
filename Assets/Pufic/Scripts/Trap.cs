using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var val = GetComponent<Targeting>();
        if (other.tag == val.TargetTag)
        {
            animator.SetBool("Closing", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var val = GetComponent<Targeting>();
        if (other.tag == val.TargetTag)
        {
            animator.SetBool("Closing", false);
        }
    }
}
