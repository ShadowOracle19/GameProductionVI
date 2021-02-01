using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace LC
{
    public class EnemyManager : CharacterManager
    {

        EnemyLocomotionManager enemyLocomotionManager;
        EnemyAnimatorManager enemyAnimatorManager;
        EnemyStats enemyStats;
        
        

        public State currentState;
        public CharacterStats currentTarget;
        public NavMeshAgent navMeshAgent;

        public bool isPerformingAction;
        public bool isInteracting;
        public Rigidbody enemyRigidbody;
        public float rotationSpeed = 25;
        public float maximumAttackRange = 1.5f;

        [Header("AI Settings")]
        public float detectionRadius = 20;

        //the higher and lower respectively these angles are the greater detection field of view (eye sight)
        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;

        public float currentRecoveryTime = 0;

        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();           
            enemyStats = GetComponent<EnemyStats>();
            enemyRigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            navMeshAgent.enabled = false;
        }
        private void Start()
        {

            enemyRigidbody.isKinematic = false;
        }

        private void Update()
        {
            HandleRecoveryTimer();

            isInteracting = enemyAnimatorManager.anim.GetBool("isInteracting");
        }
        private void FixedUpdate()
        {
            HandleStateMachine();

            
        }

        private void HandleStateMachine()
        {
            if(currentState != null)
            {
                State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);
                if(nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }

        private void SwitchToNextState(State state)
        {
            currentState = state;
        }

        private void HandleRecoveryTimer()
        {
            if(currentRecoveryTime > 0)
            {
                currentRecoveryTime -= Time.deltaTime;
            }

            if(isPerformingAction)
            {
                if(currentRecoveryTime <= 0)
                {
                    isPerformingAction = false;
                }
            }
        }

        #region Attack

        private void AttackTarget()
        {
            //if (isPerformingAction)
            //    return;

            //if(currentAttack == null)
            //{
            //    GetNewAttack();
            //}
            //else
            //{
            //    isPerformingAction = true;
            //    currentRecoveryTime = currentAttack.recoveryTime;
            //    enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
            //    currentAttack = null;
            //}
        }

        private void GetNewAttack()
        {
            //Vector3 targetDirection = enemyLocomotionManager.currentTarget.transform.position - transform.position;
            //float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
            //enemyLocomotionManager.distanceFromTarget = Vector3.Distance(enemyLocomotionManager.currentTarget.transform.position, transform.position);

            //int maxScore = 0;

            //for (int i = 0; i < enemyAttacks.Length; i++)
            //{
            //    EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            //    if(enemyLocomotionManager.distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack && enemyLocomotionManager.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            //    {
            //        if(viewableAngle <= enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
            //        {
            //            maxScore += enemyAttackAction.attackScore;
            //        }
            //    }
            //}
            //int randomValue = Random.Range(0, maxScore);
            //int tempScore = 0;

            //for (int i = 0; i < enemyAttacks.Length; i++)
            //{
            //    EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            //    if (enemyLocomotionManager.distanceFromTarget <= enemyAttackAction.maximumDistanceNeededToAttack && enemyLocomotionManager.distanceFromTarget >= enemyAttackAction.minimumDistanceNeededToAttack)
            //    {
            //        if (viewableAngle <= enemyAttackAction.maximumAttackAngle && viewableAngle >= enemyAttackAction.minimumAttackAngle)
            //        {
            //            if(currentAttack != null)
            //            {
            //                return;
            //            }
            //            tempScore += enemyAttackAction.attackScore;
            //            if(tempScore > randomValue)
            //            {
            //                currentAttack = enemyAttackAction;
            //            }
            //        }
            //    }
            //}
        }

        #endregion
    }
}

