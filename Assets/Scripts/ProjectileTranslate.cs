using UnityEngine;
using System.Collections;

// Скрип для projectile объектов (например для патрона)
public class ProjectileTranslate : MonoBehaviour
{
    public float speed = 0.1f; // Скорость полета

	// Каждый кадр перемещает объект вперед с заданной скоростью
    void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
