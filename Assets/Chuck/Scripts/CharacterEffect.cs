using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterEffect : MonoBehaviour
{
    //����� �� 0 �� 100. ���� ������������
    public float chanceToWork;

    protected abstract void action(GameObject other);

    public void tryAction(GameObject other)
    {
        //print("effect");
        if (Random.Range(0.0f, 99.0f) <= chanceToWork)
        {
            print("effect");
            action(other);
        }
    }
}
