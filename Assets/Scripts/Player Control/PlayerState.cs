using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class PlayerState
    {
        protected Player player;
        protected PlayerStateMachine stateMachine;
        private string animBoolName;

        // ĳ���� ���� ������
        public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        {
            this.player = _player;
            this.stateMachine = _stateMachine;
            this.animBoolName = _animBoolName;
        }


        // Player.cs ���� PlayerState ��ü�� ������ �� boolName�� �̹� �޾ƿ´�
        public virtual void Enter()
        {
            player.anim.SetBool(animBoolName, true);
        }

        public virtual void Update()
        {

        }

        public virtual void Exit()
        {
            player.anim.SetBool(animBoolName, false);
        }
    }
}
