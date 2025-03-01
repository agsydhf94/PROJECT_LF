using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class SkeletonBattleState : EnemyState
    {
        private Transform player;
        private EnemySkeleton enemy;
        private int moveDir;

        public SkeletonBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animationBoolName, EnemySkeleton enemy) : base(enemyBase, stateMachine, animationBoolName)
        {
            this.enemy = enemy;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Battle");

            player = GameObject.Find("Player").transform;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                stateMachine.ChangeState(enemy.attackState);
            }

            if(player.position.x > enemy.transform.position.x)
            {
                moveDir = 1;
            }
            else if(player.position.x < enemy.transform.position.x)
            {
                moveDir = -1;
            }

            enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
        }
    }
}
