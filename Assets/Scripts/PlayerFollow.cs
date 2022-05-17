using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для камеры (камера следует за игроком)
public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 cameraOffset;

	// Вычитсляется сдвиг камеры отностиельно персонажа
    void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }

	// Перемещает камеру за персонажем каждый кадр с учетом сдвига
    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);
    }
}
