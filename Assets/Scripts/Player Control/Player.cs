using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

namespace LF
{
    public class Player : MonoBehaviour
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

        [Header("Collision Information")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckDistance;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private float wallCheckDistance;
        [SerializeField] private LayerMask groundLayer;

        public int facingDirection { get; private set; } = 1;
        private bool isFacingRight = true;

        #region Components

        public Animator anim { get; private set; }
        public Rigidbody2D rb { get; private set; }

        #endregion

        
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

        private void Awake()
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

        private void Start()
        {
            anim = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();

            stateMachine.Initialize(idleState);
        }

        private void Update()
        {
            stateMachine.currentState.Update();

            // 땅에 있을 때 뿐아니라 공중에서도 대시 가능
            CheckForDashInput();
        }

        #region Velocity
        public void SetVelocity(float _xVel, float _yVel)
        {
            rb.velocity = new Vector2(_xVel, _yVel);
            FilpControl(_xVel);
        }


        public void ZeroVelocity() => rb.velocity = Vector2.zero;
        #endregion

        #region Collision
        public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, groundLayer);

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        }

        #endregion

        #region Flip
        public void Flip()
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }


        public void FilpControl(float _xInput)
        {
            if(_xInput > 0 && !isFacingRight)
            {
                Flip();
            }
            else if(_xInput < 0 && isFacingRight)
            {
                Flip();
            }
        }
        #endregion

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
