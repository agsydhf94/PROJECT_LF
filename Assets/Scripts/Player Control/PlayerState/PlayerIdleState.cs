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

            // �� �κ��� �־�� ���� �� ��� �̲������� ���� ������ �� ����
            player.ZeroVelocity();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            // �÷��̾ ���� �ε��� ���¿��� �������� �ȴ� ����� ����Ǵ� ���� ����
            if (xInput == player.facingDirection && player.IsWallDetected())
                return;

            if (xInput != 0 && !player.isBusy)
            {
                stateMachine.ChangeState(player.moveState);
            }

            
        }
    }
}