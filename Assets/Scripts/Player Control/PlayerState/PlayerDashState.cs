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

            // ���� ��� �� ���� �ε����� ��Ÿ�� ���·� ��ȯ 
            if(!player.IsGroundDetected() && player.IsWallDetected())
            {
                stateMachine.ChangeState(player.wallSlideState);
            }

            // �÷��̾ ���ϰ� �ִ� �������� dashSpeed�� �ӵ��� ���
            // ������ facingDirection�� �ƴ� dashDirection���� ����
            // y ���� velocity�� 0���� �ؼ� ���� ��� �߿� �����ϴ� ���� ����
            player.SetVelocity(player.dashSpeed * player.dashDirection, 0);

            if(stateTimer < 0)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
