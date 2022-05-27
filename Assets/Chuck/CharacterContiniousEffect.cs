using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterContiniousEffect : MonoBehaviour
{
    /*private enum Type
    {
        continious, oneTime
    }

    Type EffectType*/

    protected abstract void action();
    protected abstract float duration();
    protected abstract void setUpAction();

    private float timeBeforeDestroy;


    // Start is called before the first frame update
    void Start()
    {
        setUpAction();
        timeBeforeDestroy = duration();
    }

    // Update is called once per frame
    void Update()
    {
        action();

        timeBeforeDestroy -= Time.deltaTime;

        if (timeBeforeDestroy < 0)
        {
            Destroy(this);
        }
    }
}
