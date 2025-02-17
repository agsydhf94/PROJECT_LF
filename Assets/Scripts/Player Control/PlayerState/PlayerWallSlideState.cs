using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class PlayerWallSlideState : PlayerState
    {
        public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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


            if(yInput < 0)
            {
                // 벽타면서 아래키를 누르면 기본 낙하속도랑 동일하게 벽타기
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
                // 벽타기 속도 디폴트
                rb.velocity = new Vector2(0, rb.velocity.y * 0.7f);
            }

            // 벽 타다가 반대 방향을 누르면 벽에서 떨어짐
            if(xInput != 0 && player.facingDirection != xInput)
            {
                stateMachine.ChangeState(player.idleState);
            }

            // 땅에 떨어지면 다시 idle
            if(player.IsGroundDetected())
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
