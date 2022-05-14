using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для прицела
public class MouseFollow : MonoBehaviour
{
	public Transform player;
	public float speed;

	// Реализует перемещение объекта вместе с персонажем (перемещение персонажа применяется к данному оъекту)
	void Update()
	{
		transform.position = player.position + new Vector3(0, 1.25f, 0);
	}

	// Реализует вращение объекта в сторону мыши
	void FixedUpdate()
	{
		Plane playerPlane = new Plane(Vector3.up, transform.position);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		float hitdist = 0.0f;

		if (playerPlane.Raycast(ray, out hitdist))
		{
			Vector3 targetPoint = ray.GetPoint(hitdist);

			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}
	}
}
