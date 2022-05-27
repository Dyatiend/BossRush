using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsGenerator : MonoBehaviour
{
    private List<CharacterEffect> effects = new List<CharacterEffect>(); 
    // Start is called before the first frame update
    void Start()
    {
        var components = GetComponents<CharacterEffect>();

        foreach (CharacterEffect effect in components)
        {
            effects.Add(effect);
            print("Добавление эффекта; ");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (effects.Count == 0)
        {
            var components = GetComponents<CharacterEffect>();

            foreach (CharacterEffect effect in components)
            {
                effects.Add(effect);
            }
        }

        if (other.tag == "Player")
        {
            foreach (CharacterEffect effect in effects)
            {
                effect.tryAction(other.gameObject);
            }
        }
    }
}
