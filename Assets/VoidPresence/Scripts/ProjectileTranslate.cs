using UnityEngine;
using System.Collections;

public class ProjectileTranslate : MonoBehaviour
{
    public float speed = 0.1f;
    private Vector3 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            PlayerAttackImpact playerAttackImpact = GetComponent<PlayerAttackImpact>();
            if (playerAttackImpact) playerAttackImpact.Hit(hit.collider);

            PlayerAbilityImpact playerAbilityImpact = GetComponent<PlayerAbilityImpact>();
            if (playerAbilityImpact) playerAbilityImpact.Hit(hit.collider);

            BossAttackImpact bossAttackImpact = GetComponent<BossAttackImpact>();
            if (bossAttackImpact) bossAttackImpact.Hit(hit.collider);

            BossAbilityImpact bossAbilityImpact = GetComponent<BossAbilityImpact>();
            if (bossAbilityImpact) bossAbilityImpact.Hit(hit.collider);
        }

        lastPos = transform.position;
    }
}
