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

            player = PlayerManager.Instance.player.transform;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (enemy.IsPlayerDetected())
            {
                stateTimer = enemy.battleTime;

                if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
                {
                    if (CanAttack())
                    {
                        stateMachine.ChangeState(enemy.attackState);
                    }

                }
            }
            else
            {
                if(stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 7f)
                {
                    stateMachine.ChangeState(enemy.idleState);
                }
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

        private bool CanAttack()
        {
            if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
            {
                enemy.lastTimeAttacked = Time.time;
                return true;
            }
            Debug.Log("Attack is now Cooldown");
            return false;
        }
    }
}
