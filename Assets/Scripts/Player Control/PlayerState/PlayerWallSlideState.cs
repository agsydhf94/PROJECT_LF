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
                // ��Ÿ�鼭 �Ʒ�Ű�� ������ �⺻ ���ϼӵ��� �����ϰ� ��Ÿ��
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            else
            {
                // ��Ÿ�� �ӵ� ����Ʈ
                rb.velocity = new Vector2(0, rb.velocity.y * 0.7f);
            }

            // �� Ÿ�ٰ� �ݴ� ������ ������ ������ ������
            if(xInput != 0 && player.facingDirection != xInput)
            {
                stateMachine.ChangeState(player.idleState);
            }

            // ���� �������� �ٽ� idle
            if(player.IsGroundDetected())
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
