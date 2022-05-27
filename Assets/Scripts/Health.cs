using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Здоровье
public class Health : MonoBehaviour
{
    public int maxHealhPoints = 100;
    public int healthPoints;
    public float deathTime = 2f; // Время, которое труп пролежит на земле

    private int LOSER_SCENE = 4;

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
        if(gameObject.CompareTag("Player")) {
             Invoke(nameof(ChangeScene), deathTime);
        }
        else if(gameObject.CompareTag("Boss")) {
            Destroy(gameObject, deathTime);
        }
    }

    private void ChangeScene() {
        SceneManager.LoadScene(LOSER_SCENE);
    }
}
