using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Watts.Scripts
{
    public class WattsUltimate: Skill
    {
        public override SkillType Type() 
        {
            return SkillType.Ultimate;
        }

        public override bool NeedsMouseRotation()
        {
            return false;
        }

        protected override float ActiveTime()
        {
            return 1.6f;
        }

        protected override float ReloadTime()
        {
            return 0; //FIXME
        }

        protected override float HoldUpTime()
        {
            return 0.7f;;
        }

        private bool isActive = false;

        public GameObject projectile;
        public float spawnRadius = 0.4f;
        protected override void Action()
        {
            StartCoroutine(UltTimer());
        }
        
        IEnumerator UltTimer()
        {
            int count = 150;
            var wait = new WaitForSeconds(ActiveTime() / count);
            
            Vector3 origin = gameObject.transform.position + Vector3.up * 1.2f;

            float angleStep = (float) (360 / 1.618);
            float angle = 0;

            for (int i = 0; i < count; i++)
            {
                Quaternion rot = Quaternion.AngleAxis(angle,Vector3.up);
                Vector3 lDirection = (rot * Vector3.forward).normalized * spawnRadius;

                GameObject fired = Instantiate(projectile, origin + lDirection, rot);
                Targeting targeting = fired.GetComponent<Targeting>();
                targeting.ConfigureTargetingAs(gameObject.tag);

                angle += angleStep + i * 0.002f;

                yield return wait;
            }
        }

        public override bool BossUseConditions()
        {
            Transform target = GameObject.FindGameObjectWithTag("Player").transform;
            return base.BossUseConditions() && Vector3.Distance(transform.position, target.position) < 10 ;
        }
    }
}