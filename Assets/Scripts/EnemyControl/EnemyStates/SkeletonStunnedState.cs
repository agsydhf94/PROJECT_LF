using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonStunnedState : EnemyState
    {
        private EnemySkeleton enemy;

        public SkeletonStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            enemy.fx.InvokeRepeating("RedColorBlink", 0, 0.1f);

            stateTimer = enemy.stunnedDuration;

            rb.velocity = new Vector2(-enemy.facingDirection * enemy.stunDirection.x, enemy.stunDirection.y);
        }

        public override void Exit()
        {
            base.Exit();
            enemy.fx.Invoke("CancelRedBlink", 0);
        }

        public override void Update()
        {
            base.Update();

            if(stateTimer < 0)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }
}
