using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class PlayerGroundedState : PlayerState
    {
        public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

            if(Input.GetKey(KeyCode.Mouse0))
            {
                stateMachine.ChangeState(player.primaryAttackState);
            }

            if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
            {
                stateMachine.ChangeState(player.jumpState);
            }

            // 공중에서 대시가 끝난 후 아직 공중에 있을 때
            // 캐릭터가 아직 공중에 있는데도 걷는 모션이 재생되는 것을 방지
            if(!player.IsGroundDetected())
            {
                stateMachine.ChangeState(player.airState);
            }

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                stateMachine.ChangeState(player.dashState);
            }
        }
    }
}
