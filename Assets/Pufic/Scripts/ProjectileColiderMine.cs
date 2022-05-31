using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileColiderMine : MonoBehaviour
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
        print("�������� " + gameObject.name + " � �������� " + collider.name + ". ��� ���:" + collider.tag
        + "\n ��� ���������:" + targeting.OwnerTag + ", ��� ����:" + targeting.TargetTag);

        if (collider.CompareTag(targeting.OwnerTag))
        {
            return;
        }

        if (collider.CompareTag(targeting.TargetTag))
        {
            collider.GetComponent<Health>().TakeDamage(dealingDamage);
        }

        if (type == ProjectileType.Spark && !collider.CompareTag("trap"))
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
