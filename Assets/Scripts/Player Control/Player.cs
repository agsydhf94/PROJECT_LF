using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace LF
{
    public class Player : Entity
    {
        [Header("Attack Details")]
        public Vector2[] attackMovement;

        public bool isBusy { get; private set; }
        [Header("Move Information")]
        public float moveSpeed = 12f;
        public float jumpForce;

        [Header("Dash Information")]
        public float dashSpeed;
        public float dashDuration;
        public float dashDirection {  get; private set; }
        [SerializeField] private float dashCoolDown;
        private float dashUsedTimer;

        

        

        

        
        #region States

        public PlayerStateMachine stateMachine { get; private set; }
        public PlayerIdleState idleState { get; private set; }
        public PlayerMoveState moveState { get; private set; }
        public PlayerJumpState jumpState { get; private set; }
        public PlayerAirState airState { get; private set; }
        public PlayerWallSlideState wallSlideState { get; private set; }
        public PlayerWallJumpState wallJumpState { get; private set; }
        public PlayerDashState dashState { get; private set; }
        public PlayerPrimaryAttackState primaryAttackState { get; private set; }

        #endregion

        protected override void Awake()
        {
            stateMachine = new PlayerStateMachine();

            idleState = new PlayerIdleState(this, stateMachine, "Idle");
            moveState = new PlayerMoveState(this, stateMachine, "Move");
            jumpState = new PlayerJumpState(this, stateMachine, "Jump");
            airState = new PlayerAirState(this, stateMachine, "Jump");
            wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
            wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
            dashState = new PlayerDashState(this, stateMachine, "Dash");
            primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        }

        protected override void Start()
        {
            base.Start();

            stateMachine.Initialize(idleState);
        }

        protected override void Update()
        {
            base.Update();
            stateMachine.currentState.Update();

            // 땅에 있을 때 뿐아니라 공중에서도 대시 가능
            CheckForDashInput();
        }

        

        public void CheckForDashInput()
        {
            // 벽타기 도중에는 대시 불가
            if(IsWallDetected()) 
                return;

            dashUsedTimer -= Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.LeftShift) && dashUsedTimer < 0)
            {
                dashUsedTimer = dashCoolDown;
                dashDirection = Input.GetAxisRaw("Horizontal");
                if(dashDirection == 0)
                {
                    dashDirection = facingDirection;
                }

                stateMachine.ChangeState(dashState);
            }
        }

        public IEnumerator BusyFor(float _seconds)
        {
            isBusy = true;

            yield return new WaitForSeconds(_seconds);

            isBusy = false;
        }

        public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

        
    }
}
