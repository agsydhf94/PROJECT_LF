using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class EnemyState
    {
        protected EnemyStateMachine stateMachine;
        protected Enemy enemyBase;

        private string animationBoolName;
        protected bool triggerCalled;
        protected float stateTimer;

        public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string  animationBoolName)
        {
            this.enemyBase = enemyBase;
            this.stateMachine = stateMachine;
            this.animationBoolName = animationBoolName;
        }

        public virtual void Enter()
        {
            triggerCalled = false;
            enemyBase.anim.SetBool(animationBoolName, true);
        }

        public virtual void Update()
        {
            stateTimer -= Time.deltaTime;
        }

        public virtual void Exit()
        {
            enemyBase.anim.SetBool(animationBoolName, false);
        }
    }
}
