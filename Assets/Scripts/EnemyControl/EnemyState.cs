using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class EnemyState
    {
        protected EnemyStateMachine stateMachine;
        protected Enemy enemy;

        private string animationBoolName;
        protected bool triggerCalled;
        protected float stateTimer;

        public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string  animationBoolName)
        {
            this.enemy = enemy;
            this.stateMachine = stateMachine;
            this.animationBoolName = animationBoolName;
        }

        public virtual void Enter()
        {
            triggerCalled = false;
            enemy.anim.SetBool(animationBoolName, true);
        }

        public virtual void Update()
        {
            stateTimer -= Time.deltaTime;
        }

        public virtual void Exit()
        {
            enemy.anim.SetBool(animationBoolName, false);
        }
    }
}
