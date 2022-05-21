using System;
using System.Collections.Generic;
using UnityEngine;

//Абстрактный класс для скиллов. Все скиллы, повешенные на вашего персонажа, должны наследоваться от этого класса и иметь один из трех типов SkillType
public abstract class Skill : MonoBehaviour
{
    public enum SkillType
    {
        Attack,
        Ability,
        Ultimate
    }

    private static Dictionary<Skill.SkillType, State.States> statesMap = new Dictionary<SkillType, State.States>()
    {
        { Skill.SkillType.Attack , State.States.ATTACK},
        { Skill.SkillType.Ability , State.States.ABILITY},
        { Skill.SkillType.Ultimate, State.States.ULTIMATE}
    };

    private static Dictionary<Skill.SkillType, string> triggerMap = new Dictionary<SkillType, string>()
    {
        { Skill.SkillType.Attack , "Attack"},
        { Skill.SkillType.Ability , "Ability"},
        { Skill.SkillType.Ultimate, "Ultimate"}
    };

    //Возвращает тип реализуемого скилла; метод-константа
    public abstract SkillType Type();
    
    //Должен ли выполняться поворот персонажа в сторону курсора мыши; метод-константа
    public abstract bool NeedsMouseRotation();
    
    //Время в секундах, ожидаемое между активацией скилла и его выполнением (например, для того чтобы дать анимации проиграться); метод-константа
    protected abstract float HoldUpTime();
    
    //Время в секундах, ожидаемое между активацией скилла и его выполнением (например, для того чтобы дать анимации проиграться); метод-константа
    protected abstract float ActiveTime();
    
    //Время в секундах, необходимое для перезарядки скилла; метод-константа
    protected abstract float ReloadTime();


    //Действие, выполняемое скиллом, его "мясо"
    protected abstract void Action();
    
    
    private Animator animator;
    private State state;
    private Rigidbody rigidbody;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private bool onCoolDown = false;
    public void Perform()
    {
        if (onCoolDown)
        {
            return;
        }
        state.ChangeState(statesMap[Type()]);

        rigidbody.velocity = Vector3.zero;
        animator.SetFloat("Velocity", 0);
        animator.SetTrigger(triggerMap[Type()]);

        onCoolDown = true;
        
        Invoke(nameof(Action), HoldUpTime());
        Invoke(nameof(Finish), HoldUpTime() + ActiveTime());
        Invoke(nameof(Reload), HoldUpTime() + ActiveTime() + ReloadTime());
    }

    private void Reload()
    {
        onCoolDown = false;
    }

    private void Finish()
    {
        state.ChangeState(State.States.IDLE);
    }
}