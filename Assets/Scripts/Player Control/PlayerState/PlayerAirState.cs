using LF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        // if 안에 조건을 rb.velocity.y == 0 으로 안한 이유는 
        // 속도를 기준으로하면 예를 들어 적의 머리에서 점프를 하는 등 부자연스러운 모습이 연출됨
        if(player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }

        // 캐릭터가 공중에서 떨어질 때도 방향을 바꿀 수 있게 함
        if(xInput != 0)
        {
            player.SetVelocity(player.moveSpeed * 0.8f * xInput, rb.velocity.y);
        }

        if(player.IsWallDetected())
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
    }
}
