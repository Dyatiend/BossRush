using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterEffect : MonoBehaviour
{
    //Число от 0 до 100. Шанс срабатывания
    public float chanceToWork;

    protected abstract void action(GameObject other);

    public void tryAction(GameObject other)
    {
        if (Random.Range(0.0f, 100.0f) <= chanceToWork)
        {
            action(other);
        }
    }
}
