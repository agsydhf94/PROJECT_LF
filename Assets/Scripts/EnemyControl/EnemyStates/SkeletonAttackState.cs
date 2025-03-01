using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonAttackState : EnemyState
    {
        private EnemySkeleton enemy;

        public SkeletonAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();

            enemy.lastTimeAttacked = Time.time;
        }

        public override void Update()
        {
            base.Update();

            enemy.SetZeroVelocity();

            if(triggerCalled)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }
}
