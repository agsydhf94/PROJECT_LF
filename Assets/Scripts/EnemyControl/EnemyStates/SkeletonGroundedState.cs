using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonGroundedState : EnemyState
    {
        protected EnemySkeleton enemy;

        protected Transform player;

        public SkeletonGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();

            player = GameObject.Find("Player").transform;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if(enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2f)
            {
                stateMachine.ChangeState(enemy.battleState);
            }
        }
    }
}
