using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class EnemyState
    {
        protected EnemyStateMachine stateMachine;
        protected Enemy enemyBase;
        protected Rigidbody2D rb;

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
            rb = enemyBase.rb;
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

        public virtual void AnimationFinishTrigger()
        {
            triggerCalled = true;
        }
    }
}
