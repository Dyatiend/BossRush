using System;
using UnityEngine;

namespace Watts.Scripts
{
    public class WattsAbility: Skill
    {
        public override SkillType Type()
        {
            return SkillType.Ability;
        }

        public override bool NeedsMouseRotation()
        {
            return false;
        }

        protected override float ActiveTime()
        {
            return 0.5f;
        }

        protected override float ReloadTime()
        {
            return 0;
        }

        protected override float HoldUpTime()
        {
            return 0.0f;
        }

        public float dashSpeed = 30;

        private bool isActive = false;
        private GameObject enemy;
        private Rigidbody rigidbody;
        protected override void Action()
        {
            Targeting targeting = GetComponent<Targeting>();
            targeting.ConfigureTargetingAs(gameObject.tag);
            enemy = GameObject.FindWithTag(targeting.TargetTag);
            rigidbody = GetComponent<Rigidbody>();

            gameObject.GetComponent<Collider>().isTrigger = true;
            rigidbody.useGravity = false;
            isActive = true;

            initDirToEnemy = enemy.transform.position - transform.position;
            overshootTime = 6 / dashSpeed;
            currentOvershootTime = 0;
        }

        private Vector3 initDirToEnemy;
        private float overshootTime;
        private float currentOvershootTime = 0;
        
        private void FixedUpdate()
        {
            if (isActive)
            {
                Vector3 dirToEnemy = enemy.transform.position - transform.position;
                if (Vector3.Dot(initDirToEnemy, dirToEnemy) < 0)
                {
                    currentOvershootTime += Time.deltaTime;
                    float t = currentOvershootTime / overshootTime;
                    rigidbody.velocity = rigidbody.velocity.normalized * Mathf.SmoothStep( rigidbody.velocity.magnitude, 0, t);

                    if (rigidbody.velocity.magnitude < 0.2)
                    {
                        gameObject.GetComponent<Collider>().isTrigger = false;
                        rigidbody.useGravity = true;
                        rigidbody.velocity = Vector3.zero;
                        isActive = false;
                    }
                }
                else
                {
                    rigidbody.velocity = new Vector3(initDirToEnemy.normalized.x * dashSpeed, rigidbody.velocity.y, initDirToEnemy.normalized.z * dashSpeed);

                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(initDirToEnemy), Time.deltaTime * 20);
                }

                GetComponent<Animator>().SetFloat("Velocity", rigidbody.velocity.magnitude);

            }
        }
    }
}