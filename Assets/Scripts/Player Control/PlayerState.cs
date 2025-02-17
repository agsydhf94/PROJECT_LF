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

        protected Rigidbody2D rb;

        protected float xInput;
        protected float yInput;

        protected float stateTimer;

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
            rb = player.rb;
        }

        public virtual void Update()
        {
            stateTimer -= Time.deltaTime;

            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            player.anim.SetFloat("yVelocity", rb.velocity.y);
        }

        public virtual void Exit()
        {
            player.anim.SetBool(animBoolName, false);
        }
    }
}
