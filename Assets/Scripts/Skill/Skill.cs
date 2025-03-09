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

                // ��ų ���
                cooldownTimer = cooldown;
                return true;
            }

            Debug.Log("��ų ��ٿ� ��");
            return false;
        }

        public virtual void UseSkill()
        {
            // Ư�� ��ų ���
        }
    }
}
