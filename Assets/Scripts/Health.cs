using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int healthPoints = 100;
    public float deathTime = 2f;

    private static int LOSER_SCENE = 5;

    private Animator animator;
    private PlayerState state;

    void Start()
    {
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Invoke(nameof(Destroy), .5f);

    }

    private void Destroy()
    {
        animator.SetTrigger("Death");
        state.ChangeState(PlayerState.States.DEAD);
        if(gameObject.CompareTag("Player")) {
             Invoke(nameof(ChangeScene), deathTime);
        }
        else if(gameObject.CompareTag("Boss")) {
            Debug.Log("Открыть дверь");
            Destroy(gameObject, deathTime);
        }
    }

    private void ChangeScene() {
        SceneManager.LoadScene(LOSER_SCENE);
    }
}
