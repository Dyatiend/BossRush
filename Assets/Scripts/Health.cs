using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Здоровье
public class Health : MonoBehaviour
{
    public int maxHealhPoints = 100;
    public int healthPoints;
    public float deathTime = 2f; // Время, которое труп пролежит на земле

    private Animator animator;
    private State state;

    void Start()
    {
        healthPoints = maxHealhPoints;
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

	// Получение урона
    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Invoke(nameof(Destroy), .5f);

    }

    // Лечение
    public void Heal(int amount)
    {
        healthPoints += amount;

        if (healthPoints >= maxHealhPoints)
            healthPoints = maxHealhPoints;
    }

	// Уничтожение объекта с задержкой deathTime и проигрывание анимации смерти
    private void Destroy()
    {
        animator.SetTrigger("Death");
        state.ChangeState(State.States.DEAD);
        Destroy(gameObject, deathTime);
    }
}
