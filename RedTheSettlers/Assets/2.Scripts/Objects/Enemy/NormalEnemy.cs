using RedTheSettlers.GameSystem;
using RedTheSettlers.UnitTest;

namespace RedTheSettlers.Enemys
{
    public class NormalEnemy : Enemy
    {
        EnemyFireBall enemyFireBall;

        private void Start()
        {
            Setting();
            //SetStatus();
        }

        private void Update()
        {
            UpdatePosition();
        }

        public override void ChangeState(EnemyStateType stateType)
        {
            switch (stateType)
            {
                case EnemyStateType.Idle:
                    currentState = new Idle(this);
                    break;
                case EnemyStateType.Die:
                    currentState = new Die(this);
                    break;
                case EnemyStateType.Damage:
                    currentState = new Damage(this);
                    break;
                case EnemyStateType.Attack1:
                    currentState = new AttackPattern1(this);
                    break;
                case EnemyStateType.Attack2:
                    currentState = new AttackPattern2(this);
                    break;
                case EnemyStateType.Move:
                    currentState = new Move(this);
                    break;
                default:
                    break;
            }
            base.ChangeState(stateType);
        }

        public void SetType(EnemyType enemyType)
        {
            typeRenderer.material = materials[(int)enemyType];
        }

        private void StartAttack1()
        {
            attackArea.AttackCollider.enabled = true;
        }

        private void EndAttack()
        {
            ChangeState(EnemyStateType.Idle);
            attackArea.AttackCollider.enabled = false;
        }

        public void StartAttack2()
        {
            ChangeState(EnemyStateType.Attack2);
        }

        private void EndDamage()
        {
            ChangeState(EnemyStateType.Idle);
        }

        public EnemyFireBall PopFireBall()
        {
            enemyFireBall = ObjectPoolManager.Instance.FireballQueue.Dequeue();
            enemyFireBall.gameObject.SetActive(true);
            return enemyFireBall;
        }

        public void PushFireBall()
        {
            FireBallLifeTimer = null;
            enemyFireBall.gameObject.SetActive(false);
            ObjectPoolManager.Instance.FireballQueue.Enqueue(enemyFireBall);
        }

        //자원량을 매개변수로 받아서 enemy의 스탯 설정
        //DataManager.Instance.GameData.PlayerData[0].ResourceData.SoilNumber = 123;
        //게임매니저에서 받으면 ㄷ횐다.
        protected override void SetStatus(int playerNumber, ItemType type)
        {
            if(type == ItemType.Cow)
            {
                
            }
            
        }
    }
}