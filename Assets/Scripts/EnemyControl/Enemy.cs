using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace LF
{
    public class Enemy : Entity
    {
        [SerializeField] protected LayerMask whatIsPlayer;

        [Header("Stunned Information")]
        public float stunnedDuration;
        public Vector2 stunDirection;
        protected bool canBeStunned;
        [SerializeField] protected GameObject counterImage;

        [Header("Move Information")]
        public float moveSpeed;
        public float idleTime;
        public float battleTime;

        [Header("Attack Information")]
        public float attackDistance;
        public float attackCooldown;
        [HideInInspector] public float lastTimeAttacked;

        public EnemyStateMachine stateMachine { get; private set; }


        protected override void Awake()
        {
            stateMachine = new EnemyStateMachine();
        }

        protected override void Update()
        {
            base.Update();

            stateMachine.currentState.Update();
        }

        public virtual void OpenCounterAttackWinow()
        {
            canBeStunned = true;
            counterImage.SetActive(true);
        }

        public virtual void CloseCounterAttackWindow()
        {
            canBeStunned = false;
            counterImage.SetActive(false);
        }

        protected virtual bool CanBeStunned()
        {
            if(canBeStunned)
            {
                CloseCounterAttackWindow();
                return true;
            }

            return false;
        }

        public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();

        public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, 50, whatIsPlayer);

        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();

            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDirection, transform.position.y));
        }
    }
}

