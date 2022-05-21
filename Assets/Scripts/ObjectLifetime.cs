using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectLifetime : MonoBehaviour
{
        public float destroyAfter = 1;
        private float lifetime = 0;

        private void Update()
        {
                lifetime += Time.deltaTime;
                if (lifetime >= destroyAfter)
                {
                        Object.Destroy(gameObject);
                }
        }
}