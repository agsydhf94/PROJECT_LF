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

            // 공중 대시 중 벽에 부딪히면 벽타기 상태로 전환 
            if(!player.IsGroundDetected() && player.IsWallDetected())
            {
                stateMachine.ChangeState(player.wallSlideState);
            }

            // 플레이어가 향하고 있던 방향으로 dashSpeed의 속도로 대시
            // 방향은 facingDirection이 아닌 dashDirection으로 통제
            // y 방향 velocity를 0으로 해서 공중 대시 중에 낙하하는 것을 방지
            player.SetVelocity(player.dashSpeed * player.dashDirection, 0);

            if(stateTimer < 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
