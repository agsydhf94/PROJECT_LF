using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class DashSkill : Skill
    {
        public override void UseSkill()
        {
            base.UseSkill();

            Debug.Log("대시 스킬");
        }
    }
}
