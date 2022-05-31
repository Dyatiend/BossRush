using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{

    private Collider collider;
    private Light light;

    void Start()
    {
        Destroy(gameObject, 7f);
        collider = GetComponent<CapsuleCollider>();
        Invoke(nameof(turnOffCollider), 5.2f);
        Invoke(nameof(turnOffLight), 5.8f);
        light = GetComponentInChildren<Light>();
        StartCoroutine(destroyEffect());
    }

    void Update()
    {
       
    }

    private void turnOffCollider()
    {
        collider.enabled = false;
    }

    private void turnOffLight()
    {
        light.enabled = false;
    }

    IEnumerator destroyEffect()
    {
        yield return new WaitForSeconds(5f);
        light.intensity = 8;
        yield return new WaitForSeconds(0.2f);
        light.intensity = 6;
        yield return new WaitForSeconds(0.2f);
        light.intensity = 4;
        yield return new WaitForSeconds(0.2f);
        light.intensity = 2;
    }
}
