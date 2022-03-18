using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int dealingDamage;
    void Start()
    {

    }

    private bool onObjWithoutHealth;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != ("hasHealth"))
        {
            Debug.Log("hit");
           onObjWithoutHealth = true;
        }
        if (collider.tag == ("hasHealth") && !onObjWithoutHealth)
        {
            collider.GetComponent<health>().TakeDamage(dealingDamage);
        }
    }

    void OnTriggerExit(Collider collider)  
    {
        
        if (collider.tag != ("hasHealth"))
        {
            onObjWithoutHealth = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
