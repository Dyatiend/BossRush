using System;
using UnityEngine;
using System.Collections;

//Скрипт-компонент для определения целей умений и снарядов.
public class Targeting : MonoBehaviour
{
    private string ownerTag;
    private string targetTag;

    //Используйте эту функцию при создании создании объекта, имеющего цель
    public void ConfigureTargetingAs(string ownerTag)
    {
        this.ownerTag = ownerTag;
        this.targetTag = EnemyTag(ownerTag);
    }

    public static string EnemyTag(string currentTag)
    {
        if (currentTag == "Player")
        {
            return "Boss";
        }
        else if (currentTag == "Boss")
        {
            return "Player";
        }
        else
        {
            throw new ArgumentException("Unknown targeting tag: " + currentTag);
        }
    }
    
    //Это геттеры. Используйте их (через GetComponent<Targeting>() или GetComponentInParent<Targeting>()) в скриптах,
    //которые вы повесите на свои умения и снаряды, чтобы для определить кто является их целью, а не переписывать два раза одинаковый код для разных сторон (Смотрю на тебя, Андрей)
    public string OwnerTag => ownerTag;
    public string TargetTag => targetTag;
}