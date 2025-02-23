using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{

    public class PlayerPrimaryAttackState : PlayerState
    {
        private int comboCounter;

        private float lastTimeAttacked;
        private float comboWindow = 2;


        public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            // ���� ��Ÿ�� : Time > ������ ������ �ð� + ��Ÿ�� ����
            if(comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            {
                comboCounter = 0;
            }

            player.anim.SetInteger("ComboCounter", comboCounter);

            player.SetVelocity(player.attackMovement[comboCounter].x * player.facingDirection, player.attackMovement[comboCounter].y);

            // ������ ���۵Ǹ� ���ڸ��� ������� ��¦ �����̸� �־ ������ ǥ��
            stateTimer = 0.1f;
        }

        public override void Exit()
        {
            base.Exit();

            player.StartCoroutine("BusyFor", 0.15f);

            comboCounter++;
            lastTimeAttacked = Time.time;
        }

        public override void Update()
        {
            base.Update();

            if(stateTimer < 0)
            {
                player.ZeroVelocity();
            }

            if(triggerCalled)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
