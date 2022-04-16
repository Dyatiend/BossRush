using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int Speed;
    Vector3 lastPos;

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
        if(Physics.Linecast(lastPos, transform.position, out hit)) {
            print(hit.transform.name);

            Destroy(gameObject);
        }
        lastPos = transform.position;
        
    }
}
