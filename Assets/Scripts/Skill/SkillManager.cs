using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkillManager : SingletonBase<SkillManager>
    {
        public DashSkill dashSkill { get; private set; }

        private void Start()
        {
            dashSkill = GetComponent<DashSkill>();
        }
    }
}
