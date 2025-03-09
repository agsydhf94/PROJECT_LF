using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class CloneSkill : Skill
    {
        [Header("Clone Information")]
        [SerializeField] private GameObject clonePrefab;
        [SerializeField] private float cloneDuration;


        public void CreateClone(Transform clonePosition)
        {
            GameObject newClone = Instantiate(clonePrefab);
            newClone.GetComponent<CloneSkillController>().SetupClone(clonePosition, cloneDuration);
        }
    }
}
