using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class EnemySkeleton : Enemy
    {
        #region States
        public SkeletonIdleStste idleState { get; private set; }
        public SkeletonMoveState moveState { get; private set; }
        public SkeletonBattleState battleState { get; private set; }
        public SkeletonAttackState attackState { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();

            idleState = new SkeletonIdleStste(this, stateMachine, "Idle", this);
            moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
            battleState = new SkeletonBattleState(this, stateMachine, "Move", this);
            attackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Initialize(idleState);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
