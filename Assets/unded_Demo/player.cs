using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float speed;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //public int health;
    public Slider slider;

    private Vector3 walkPoint;

    private CharacterController controller;
    private Animator animator;

    private float rotatate = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GetComponent<health>().healthPoints;

        walkPoint = Vector3.zero;

        //walkPoint.x = Input.GetAxis("Horizontal") * speed;
        walkPoint.z = Input.GetAxis("Vertical") * speed;
        if(Input.GetAxis("Horizontal") > 0) {
            rotatate += 0.5f;
        }
        else if(Input.GetAxis("Horizontal") < 0) {
            rotatate -= 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) attack();
        else if (rotatate != 0 || walkPoint.z != 0) walk();
        else stay();
    }

    private void stay()
    {
        animator.SetBool("walk", false);
    }

    private void attack()
    {
        if (!alreadyAttacked)
        {
            animator.SetTrigger("attack");
            //TakeDamage(10);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void walk()
    {
        // if (Vector3.Angle(Vector3.forward, walkPoint) > 1f || Vector3.Angle(Vector3.forward, walkPoint) == 0)
        // {
        //     Vector3 dir = Vector3.RotateTowards(transform.forward, walkPoint, speed, 0f);
        //     transform.rotation = Quaternion.LookRotation(dir);
        // }

        
        if(!alreadyAttacked)
        {
            transform.Rotate(0, rotatate, 0);
            animator.SetBool("walk", true);
            walkPoint = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * walkPoint * speed;
            controller.Move(walkPoint * Time.deltaTime);
            rotatate = 0f;
        }
    }
}
