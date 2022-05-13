using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;
    private int currentAbility;

    public GameObject hammer;
    private Collider hammerCollider;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hammerCollider = hammer.GetComponent<Collider>();
        disableHammerCollider();
        currentAbility = 1;
    }

    
    void Update()
    {
        Vector3 forward = transform.forward;
        Debug.Log(currentAbility);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentAbility = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentAbility = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentAbility = 3;
        }
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }

    void attack()
    {
        hammerCollider.enabled = true;
        switch (currentAbility)
        {
            case 1:
                animator.Play("Attack");
                break;
            case 2:
                animator.Play("Spell");
                break;
            case 3:
                animator.Play("MegaPunch");
                break;
        }
        
    }

    void disableHammerCollider()
    {
        hammerCollider.enabled = false;
    }
 
}
