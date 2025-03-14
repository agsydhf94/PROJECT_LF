using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonIdleStste : SkeletonGroundedState
    {

        public SkeletonIdleStste(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName, enemy)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            stateTimer = enemy.idleTime;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if(stateTimer < 0f)
            {
                stateMachine.ChangeState(enemy.moveState);
            }
        }
    }
}
