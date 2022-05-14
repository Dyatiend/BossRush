using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int Speed;
    public int TimeDestroy;
    Vector3 beginPos;

    void Start()
    {
        beginPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        /*RaycastHit hit;

        if (Physics.Linecast(beginPos, transform.position, out hit))
        {
            print(hit.transform.name);

            Destroy(gameObject);
        }

        Destroy(gameObject, TimeDestroy);*/
    }
}
