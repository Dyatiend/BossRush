using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StartFight : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == ("Player") && GameObject.FindGameObjectsWithTag("Boss").Length != 0)
        {
            foreach(GameObject door in GameObject.FindGameObjectsWithTag("Door"))
            {
                door.GetComponent<Animator>().SetBool("Opened", false);
            }
            GameObject.FindGameObjectsWithTag("Boss")[0].GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
