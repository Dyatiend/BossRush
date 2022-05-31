using UnityEngine;

public class Hammer : MonoBehaviour
{
    public int damage;
    public string owner;
    public string target;

    void Start()
    {

    }


    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        //Debug.Log(other.name);
    }
}
