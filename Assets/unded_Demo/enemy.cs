using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    public float timeBetweenMegaAttacks;
    private bool alreadyAttacked;
    private bool alreadyMegaAttacked;
    private bool inMegaAtaka;

    public float sightRange, attackRange, megaAttackRange;
    private bool playerInSightRange, playerInAttackRange, playerInMegaAttackRange;

    //public float health;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = GetComponent<health>().healthPoints;

        playerInSightRange = Vector3.Distance(transform.position, target.position) <= sightRange;
        playerInAttackRange = Vector3.Distance(transform.position, target.position) <= attackRange;
        playerInMegaAttackRange = Vector3.Distance(transform.position, target.position) <= megaAttackRange;

        if(inMegaAtaka) MegaAttack();
        if (!playerInSightRange && !playerInAttackRange && !playerInMegaAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange && !playerInMegaAttackRange) ChasePlayer();
        if (playerInSightRange && !playerInAttackRange && playerInMegaAttackRange && !alreadyMegaAttacked) MegaAttack();
        if (playerInSightRange && !playerInAttackRange && playerInMegaAttackRange && alreadyMegaAttacked) ChasePlayer();
        if (playerInSightRange && playerInAttackRange && playerInMegaAttackRange && !alreadyMegaAttacked) MegaAttack();
        if (playerInSightRange && playerInAttackRange && playerInMegaAttackRange && alreadyMegaAttacked) AttackPlayer();
    }
    bool test1 = true;
    private void Patroling()
    {
        //animator.SetBool("walk", false);
        
        if (!alreadyMegaAttacked && test1)
        {
            test1 = false;
            Invoke(nameof(test), 10);
        }
        /*if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            animator.SetBool("walk", true);
            navMeshAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }*/
    }

    /*private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        walkPointSet = true;
    }*/

    private void test()
    {
        //transform.Rotate(0, 90, 0);
        //animator.SetTrigger("mega_ataka");
        transform.LookAt(target.position);
        animator.Play("mega_ataka");
        alreadyMegaAttacked = true;
        inMegaAtaka = true;
        Invoke(nameof(ResetMegaAttack), timeBetweenMegaAttacks);
        Invoke(nameof(ResetInMegaAttack), 1);
    }

    private void ChasePlayer()
    {
        if (!alreadyAttacked && !inMegaAtaka)
        {
            animator.SetBool("walk", true);
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void MegaAttack()
    {
        navMeshAgent.SetDestination(transform.position);

        

        if (!alreadyMegaAttacked)
        {
            

            animator.SetTrigger("mega_ataka");

            alreadyMegaAttacked = true;
            inMegaAtaka = true;
            Invoke(nameof(ResetMegaAttack), timeBetweenMegaAttacks);
            Invoke(nameof(ResetInMegaAttack), 1);
        }
    }

    private void ResetInMegaAttack()
    {
        inMegaAtaka = false;
        //transform.Rotate(0, 90, 0);
    }

    private void ResetMegaAttack()
    {
        alreadyMegaAttacked = false;
    }

    private void AttackPlayer()
    {
        navMeshAgent.SetDestination(transform.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            animator.SetTrigger("attack");
           
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
