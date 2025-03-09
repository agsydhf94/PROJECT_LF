using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkillManager : SingletonBase<SkillManager>
    {
        public DashSkill dashSkill { get; private set; }
        public CloneSkill cloneSkill { get; private set; }

        private void Start()
        {
            dashSkill = GetComponent<DashSkill>();
            cloneSkill = GetComponent<CloneSkill>();
        }
    }
}
