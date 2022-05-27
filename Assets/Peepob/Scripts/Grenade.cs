using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    AudioSource audio;
    MeshRenderer meshRenderer;
    public float delay = 3f;
    public GameObject explosionEffect;
    public float radius = 3f;
    float countdown;
    bool hasExploded = false;

    public int damageForPlayer = 200;

    public int damageForBoss = 100;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded) {
            Explode();
            hasExploded = true;
        }
    }

    void Explode() {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        audio.Play();
        Destroy(explosion, 1f);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in colliders) {
            if (collider.gameObject.CompareTag("Player")) {
                collider.GetComponent<Health>().TakeDamage(damageForPlayer);
            }
            if (collider.gameObject.CompareTag("Boss")) {
                collider.GetComponent<Health>().TakeDamage(damageForBoss);
            }
        }
        
        Destroy(meshRenderer);
        Destroy(gameObject, 1f);
    }
}
