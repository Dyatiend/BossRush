using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsGenerator : MonoBehaviour
{
    public List<CharacterEffect> effects = new List<CharacterEffect>(); 
    // Start is called before the first frame update
    void Start()
    {
        var components = GetComponents<CharacterEffect>();
        foreach (var component in components)
        {
            effects.Add(component);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == GetComponent<Targeting>().TargetTag)
        {
            foreach (CharacterEffect effect in effects)
            {
                effect.tryAction(other.gameObject);
            }
        }
    }
}
