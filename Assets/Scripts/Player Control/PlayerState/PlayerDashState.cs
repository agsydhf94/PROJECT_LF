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

            // ��ð� ���� Ÿ�ֿ̹� �ӵ��� 0���� ����, �� �κ��� ������ ��ð� ��� ������ 
            player.SetVelocity(0, rb.velocity.y);
        }

        public override void Update()
        {
            base.Update();

            // �÷��̾ ���ϰ� �ִ� �������� dashSpeed�� �ӵ��� ���
            player.SetVelocity(player.dashSpeed * player.facingDirection, rb.velocity.y);

            if(stateTimer < 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
