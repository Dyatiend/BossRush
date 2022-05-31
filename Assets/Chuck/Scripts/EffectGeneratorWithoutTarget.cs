using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGeneratorWithoutTarget : MonoBehaviour
{
    public List<CharacterEffect> effects = new List<CharacterEffect>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (effects.Count == 0)
        {
            var components = gameObject.GetComponents<CharacterEffect>();
            foreach (CharacterEffect component in components)
            {
                effects.Add(component);
            }
        }
        
        foreach (CharacterEffect effect in effects)
        {
            effect.tryAction(other.gameObject);
        }
    }
}
