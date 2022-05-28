using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLight : MonoBehaviour
{
    private Light light;
    private bool lighting;
    void Start()
    {
        light = GetComponent<Light>();
        lighting = true;
        Invoke(nameof(Dolighting), Random.Range(0, 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!lighting)
        {
            StartCoroutine(lightEffect());
        }
    }

    private void Dolighting()
    {
        lighting = false;
    }


    IEnumerator lightEffect()
    {
        lighting = true;
        yield return new WaitForSeconds(0.18f);
        light.intensity = 6.4f;
        yield return new WaitForSeconds(0.18f);
        light.intensity = 6;
        yield return new WaitForSeconds(0.18f);
        light.intensity = 5.8f;
        yield return new WaitForSeconds(0.18f);
        light.intensity = 5.2f;
        yield return new WaitForSeconds(0.18f);
        light.intensity = 5.4f;
        yield return new WaitForSeconds(0.18f);
        light.intensity = 6;
        lighting = false;
    }
}
