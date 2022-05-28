using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    public bool opened;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Opened", opened);
    }

    void Update()
    {
        if(!animator.GetBool("Opened") && GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            animator.SetBool("Opened", true);
        }
    }
}
