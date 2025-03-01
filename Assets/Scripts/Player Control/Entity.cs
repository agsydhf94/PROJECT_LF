using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LF
{
    public class Entity : MonoBehaviour
    {
        [Header("Collision Information")]
        public Transform attackCheck;
        public float attackCheckRadius;
        [SerializeField] protected Transform groundCheck;
        [SerializeField] protected float groundCheckDistance;
        [SerializeField] protected Transform wallCheck;
        [SerializeField] protected float wallCheckDistance;
        [SerializeField] protected LayerMask groundLayer;

        #region Components
        public Animator anim { get; private set; }
        public Rigidbody2D rb { get; private set; }
        public EntityFX fx { get; private set; }
        #endregion

        public int facingDirection { get; private set; } = 1;
        protected bool isFacingRight = true;

        protected virtual void Awake()
        {

        }

        protected virtual void Start()
        {
            anim = GetComponentInChildren<Animator>();
            rb = GetComponent<Rigidbody2D>();
            fx = GetComponent<EntityFX>();
        }

        protected virtual void Update()
        {

        }

        public virtual void Damage()
        {
            Debug.Log(gameObject.name + "DAMAGED");
            fx.StartCoroutine("FlashFX");
        }

        #region Velocity
        public void SetVelocity(float _xVel, float _yVel)
        {
            rb.velocity = new Vector2(_xVel, _yVel);
            FilpControl(_xVel);
        }


        public void SetZeroVelocity() => rb.velocity = Vector2.zero;
        #endregion

        #region Flip
        public virtual void Flip()
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0, 180, 0);
        }


        public virtual void FilpControl(float _xInput)
        {
            if (_xInput > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (_xInput < 0 && isFacingRight)
            {
                Flip();
            }
        }
        #endregion

        #region Collision
        public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, groundLayer);

        protected virtual void OnDrawGizmos()
        {
            Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
            Gizmos.DrawSphere(attackCheck.position, attackCheckRadius);
        }

        #endregion

    }
}
