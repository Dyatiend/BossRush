using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для игрока/босса, реализует состояние персонажа
public class State : MonoBehaviour
{
    public enum States
    {
        IDLE,
        RUN,
        ATTACK, // Обычная атака
        ABILITY, // Сопособность (послабее)
        ULTIMATE, // Ультимативная способность (посильнее) (может быть стоит переименовать)
        DEAD,
        STUN
    }

    private States state;

	// Изменить состояние на заданное
    public void ChangeState(States state)
    {
		// Из состояния смерти нельзя выйти, из состояния стана выход осуществялется отдельной функцией
        if(this.state != States.DEAD && this.state != States.STUN) this.state = state;
    }

	// Выход из состояния стана
	// Нужна, чтобы нельзя было перейти из состояния стана сразу в состояние атаки (может быть стоит убрать)
    public void UndoStun()
    {
        if (state == States.STUN) state = States.IDLE;
    }

    public States GetState()
    {
        return this.state;
    }

    public bool CheckState(States state)
    {
        return GetState() == state;
    }
	
    void Start()
    {
        ChangeState(States.IDLE);
    }
}
