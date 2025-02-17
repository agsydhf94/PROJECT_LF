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

        // 캐릭터 상태 생성자
        public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        {
            this.player = _player;
            this.stateMachine = _stateMachine;
            this.animBoolName = _animBoolName;
        }


        // Player.cs 에서 PlayerState 객체를 생성할 때 boolName을 이미 받아온다
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
