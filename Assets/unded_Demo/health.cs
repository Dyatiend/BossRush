using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int healthPoints;
    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Invoke(nameof(DestroyEnemy), .5f);

    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}