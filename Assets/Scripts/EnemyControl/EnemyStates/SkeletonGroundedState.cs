using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonGroundedState : EnemyState
    {
        protected EnemySkeleton enemy;

        public SkeletonGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName)
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
        }

        public override void Update()
        {
            base.Update();

            if(enemy.IsPlayerDetected())
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }
}
