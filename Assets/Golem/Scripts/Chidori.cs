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
    private Light light;

    public ParticleSystem electricity;
    private bool lighting;

    void Start()
    {
        beginPos = transform.position;
        canMove = false;
        lighting = false;

        collider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        light = GetComponentInChildren<Light>();
        //electricity = GetComponentInChildren<GameObject>().GetComponent<ParticleSystem>(); 

        projectileSound = GetComponent<AudioSource>();
        projectileSound.Play();
        Invoke(nameof(allowMove), 1f);

        
    }

    void Update()
    {       
        RaycastHit hit;
        if (!lighting)
        {
            StartCoroutine(lightEffect());
        }
       
        if (Physics.Linecast(beginPos, transform.position, out hit))
        {           
            if (hit.transform.name != "Chidori(Clone)" && hit.transform.name != "Tornado(Clone)")
            {
                //print(hit.transform.name);
                canMove = false;

                StartCoroutine(destroyEffect(electricity));
                Invoke(nameof(DestroyChidori), 1.5f);
            
            }         
        }

        Invoke(nameof(DestroyChidori), TimeDestroy);

        if (canMove)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
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
        var shape = electricity.shape;
        shape.radius = 2;
        electricity.emissionRate = 150;

        yield return new WaitForSeconds(0.5f);
        collider.radius = 1.2f;
        electricity.startLifetime = 1f;
        shape.radius = 4;
        electricity.emissionRate = 100;

        yield return new WaitForSeconds(0.3f);
        collider.radius = 1.4f;
        shape.radius = 8;
        electricity.emissionRate = 50;

        yield return new WaitForSeconds(0.3f);
        collider.radius = 1.8f;
        shape.radius = 18;
        electricity.emissionRate = 10;
    }

    IEnumerator lightEffect()
    {
        lighting = true;
        light.intensity = 12;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 8;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 14;
        yield return new WaitForSeconds(0.1f);
        light.intensity = 6;
        lighting = false;
    }

}


