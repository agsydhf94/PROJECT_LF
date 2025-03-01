using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonMoveState : SkeletonGroundedState
    {
        public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName, enemy)
        {
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

            enemy.SetVelocity(enemy.moveSpeed * enemy.facingDirection, rb.velocity.y);
            if(enemy.IsWallDetected() || !enemy.IsGroundDetected())
            {
                enemy.Flip();
                stateMachine.ChangeState(enemy.idleStste);
            }
        }
    }
}
