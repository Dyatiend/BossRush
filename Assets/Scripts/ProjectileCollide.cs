using System;
using UnityEngine;

public class ProjectileCollide : MonoBehaviour
{
    public enum ProjectileType
    {
        Spark,
        Slice,
    }

    public ProjectileType type;
    public int dealingDamage;
    private Targeting targeting;
    private Animator animator;

    private void Start()
    {
        targeting = GetComponent<Targeting>();
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        print("Коллизия " + gameObject.name + " с объектом " +collider.name + ". Его тег:" + collider.tag
        + "\n Тег создателя:" + targeting.OwnerTag + ", тег цели:" + targeting.TargetTag);
        
        if(collider.CompareTag(targeting.OwnerTag))
        {
            return;
        }
        
        if (collider.CompareTag(targeting.TargetTag))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
        }
        
        if (type == ProjectileType.Spark)
        {
            SelfDestruct();
        }
    }

    private void SelfDestruct()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }
        Destroy(gameObject);
    }
        
}