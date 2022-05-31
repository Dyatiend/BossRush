using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCaws : MonoBehaviour
{
    public int Speed;
    public int TimeDestroy;
    Vector3 lastPos;
    public int damageForPlayer = 100;

    public int damageForBoss = 50;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        RaycastHit hit;

        Debug.DrawLine(lastPos, transform.position);
        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            print(hit.transform.name);
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                hit.collider.GetComponent<Health>().TakeDamage(damageForPlayer);
            }
            if (hit.collider.gameObject.CompareTag("Boss"))
            {
                hit.collider.GetComponent<Health>().TakeDamage(damageForBoss);
            }
            if (!hit.collider.gameObject.CompareTag("trap"))
            {
                Destroy(gameObject);
            }
        }
        lastPos = transform.position;

        Destroy(gameObject, TimeDestroy);

    }
}
