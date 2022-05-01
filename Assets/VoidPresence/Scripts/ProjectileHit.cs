using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public float destroyTime = 1f;
    public float hitTime = 2f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Invoke(nameof(PlayHitAnim), hitTime);
    }

    public void PlayHitAnim()
    {
        animator.SetTrigger("Hit");
        Destroy(gameObject, destroyTime);
    }
}
