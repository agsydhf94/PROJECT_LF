using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] protected float cooldown;
        protected float cooldownTimer;

        protected virtual void Update()
        {
            cooldownTimer -= Time.deltaTime;
        }

        public virtual bool CanUseSkill()
        {
            if(cooldownTimer < 0)
            {
                UseSkill();

                // 스킬 사용
                cooldownTimer = cooldown;
                return true;
            }

            Debug.Log("스킬 쿨다운 중");
            return false;
        }

        public virtual void UseSkill()
        {
            // 특정 스킬 사용
        }
    }
}
