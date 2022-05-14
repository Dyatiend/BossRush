using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Здоровье
public class Health : MonoBehaviour
{
    public int healthPoints = 100;
    public float deathTime = 2f; // Время, которое труп пролежит на земле

    private Animator animator;
    private State state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<State>();
    }

	// Получение урона
    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Invoke(nameof(Destroy), .5f);

    }

	// Уничтожение объекта с задержкой deathTime и проигрывание анимации смерти
    private void Destroy()
    {
        animator.SetTrigger("Death");
        state.ChangeState(State.States.DEAD);
        Destroy(gameObject, deathTime);
    }
}
