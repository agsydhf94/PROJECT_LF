using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LF
{
    public class Enemy : Entity
    {
        [Header("Move Information")]
        public float moveSpeed;
        public float idleTime;

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
    }
}

