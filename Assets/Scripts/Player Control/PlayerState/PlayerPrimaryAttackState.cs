using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{

    public class PlayerPrimaryAttackState : PlayerState
    {
        public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

            if(triggerCalled)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
    }
}
