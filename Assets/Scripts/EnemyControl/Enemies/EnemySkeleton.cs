using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class EnemySkeleton : Enemy
    {
        #region States
        public SkeletonIdleStste idleStste { get; private set; }
        public SkeletonMoveState moveState { get; private set; }
        #endregion

        protected override void Awake()
        {
            base.Awake();

            idleStste = new SkeletonIdleStste(this, stateMachine, "Idle", this);
            moveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Initialize(idleStste);
        }

        protected override void Update()
        {
            base.Update();
        }
    }
}
