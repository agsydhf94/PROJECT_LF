using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class PlayerIdleState : PlayerGroundedState
    {
        public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // 이 부분이 있어야 착지 후 계속 미끄러지는 것을 방지할 수 있음
            player.ZeroVelocity();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            // 플레이어가 벽에 부딪힌 상태에서 벽쪽으로 걷는 모션이 재생되는 것을 방지
            if (xInput == player.facingDirection && player.IsWallDetected())
                return;

            if (xInput != 0 && !player.isBusy)
            {
                stateMachine.ChangeState(player.moveState);
            }

            
        }
    }
}