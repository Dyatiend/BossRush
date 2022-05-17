using UnityEngine;
using System.Collections;

public class Chidori : MonoBehaviour
{
    public int Speed;
    public int TimeDestroy;
    Vector3 beginPos;

    private AudioSource projectileSound;
    private bool canMove;

    private SphereCollider collider;
    private Rigidbody rb;

    public ParticleSystem electricity;

    void Start()
    {
        beginPos = transform.position;
        canMove = false;

        collider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        //electricity = GetComponentInChildren<GameObject>().GetComponent<ParticleSystem>(); 

        projectileSound = GetComponent<AudioSource>();
        projectileSound.Play();
        Invoke(nameof(allowMove), 1f);

        
    }

    void Update()
    {
        if (canMove)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        RaycastHit hit;

        if (Physics.Linecast(beginPos, transform.position, out hit))
        {
            
            if (hit.transform.name != "Chidori(Clone)")
            {
                print(hit.transform.name);
                canMove = false;

                StartCoroutine(destroyEffect(electricity));
                Invoke(nameof(DestroyChidori), 1.5f);
            
            }         
        }

        Invoke(nameof(DestroyChidori), TimeDestroy);
    }


    private void allowMove()
    {
        canMove = true;
    }

    private void DestroyChidori()
    {
        Destroy(gameObject);
    }

    IEnumerator destroyEffect(ParticleSystem electricity)
    {
        electricity.startLifetime = 0.4f;
        var shape = electricity.shape;
        shape.radius = 2;
        electricity.emissionRate = 100;
        yield return new WaitForSeconds(0.2f);
        shape.radius = 4;
        electricity.emissionRate = 40;
        yield return new WaitForSeconds(0.3f);
        shape.radius = 8;
        electricity.emissionRate = 10;
        yield return new WaitForSeconds(0.3f);
        shape.radius = 18;
        electricity.emissionRate = 4;
    }




}
