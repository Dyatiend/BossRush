using System;
using UnityEngine;

namespace Watts.Scripts
{
    public class WattsBulletWave : MonoBehaviour
    {
        private float lifetime = 0;
        public float turnAmount = 1f;
        void FixedUpdate ()
        {
            /*lifetime += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, 1+Mathf.Sin(lifetime * speed) * wobbleCoef, transform.position.z);*/
            transform.RotateAround(transform.position, Vector3.up, turnAmount);
        }
    }
}