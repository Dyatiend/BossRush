using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnMouseLook : MonoBehaviour
{
	public Transform playerTransform;
	public float speed;

	void Update() {
		// Vector3 pos = playerTransform.position;
        // pos.y += 1;
		// transform.position = pos;
		transform.position = playerTransform.position + new Vector3(0, 1.25f, 0);
	}

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
