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

            // 공격 쿨타임 : Time > 마지막 순간의 시간 + 쿨타임 간격
            if(comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindow)
            {
                comboCounter = 0;
            }

            player.anim.SetInteger("ComboCounter", comboCounter);

            // 공격이 시작되면 제자리에 서기까지 살짝 딜레이를 주어서 관성을 표현
            stateTimer = 0.1f;
        }

        public override void Exit()
        {
            base.Exit();

            comboCounter++;
            lastTimeAttacked = Time.time;
        }

        public override void Update()
        {
            base.Update();

            if(stateTimer < 0)
            {
                rb.velocity = new Vector2(0, 0);
            }

            if(triggerCalled)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
