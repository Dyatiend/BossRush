using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для камеры (камера следует за игроком)
public class PlayerFollow : MonoBehaviour
{
    private Transform playerTransform;

    public Vector3 cameraRelativePosition;
    public Vector3 cameraRotation;

	// Вычитсляется сдвиг камеры отностиельно персонажа
    void Start()
    {
        playerTransform = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        
        transform.rotation = Quaternion.Euler(cameraRotation);
    }

	// Перемещает камеру за персонажем каждый кадр с учетом сдвига
    void LateUpdate()
    {
        Vector3 newPos = playerTransform.position + cameraRelativePosition;

        transform.position = Vector3.Slerp(transform.position, newPos, 1);
    }
}
