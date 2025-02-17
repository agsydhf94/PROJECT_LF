using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class PlayerDashState : PlayerState
    {
        public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            stateTimer = player.dashDuration;
        }

        public override void Exit()
        {
            base.Exit();

            // 대시가 끝날 타이밍에 속도를 0으로 만듬, 이 부분이 없으면 대시가 계속 유지됨 
            player.SetVelocity(0, rb.velocity.y);
        }

        public override void Update()
        {
            base.Update();

            // 플레이어가 향하고 있던 방향으로 dashSpeed의 속도로 대시
            player.SetVelocity(player.dashSpeed * player.facingDirection, rb.velocity.y);

            if(stateTimer < 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
