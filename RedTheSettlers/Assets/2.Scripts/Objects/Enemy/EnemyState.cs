using RedTheSettlers.GameSystem;
using UnityEngine;

namespace RedTheSettlers.Enemys
{
    public abstract class EnemyState
    {
        protected EnemyFireBall fireBall;
        protected GameTimer fireballTimer;
        protected GameTimer deadTimer;
        protected GameTimer Pattern1Timer;
        protected GameTimer Pattern2Timer;
        protected Animator animator;
        protected Quaternion rotation;
        protected Vector3 velocity;
        protected Vector3 targetPosition;
        protected Vector3 position;
        protected Vector3 destinationPoint;
        protected Vector3 currentPoint;
        
        protected TimerCallback pushFireball;
        protected ChangeStateCallback changeStateCallback;
        protected DeadTimerCallback deadTimerCallback;

        protected float moveSpeed;
        protected float fireballSpeed;
        protected float timeToReturn;

        public abstract void DoAction();
    }
}