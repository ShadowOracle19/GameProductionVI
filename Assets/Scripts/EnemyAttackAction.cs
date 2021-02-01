using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    [CreateAssetMenu(menuName ="AI/Enemy Actions/Attack Action")]
    public class EnemyAttackAction : EnemyActions
    {
        public int attackScore = 3;
        public float recoveryTime = 4;

        public float maximumAttackAngle = 35;
        public float minimumAttackAngle = -35;

        public float minimumDistanceNeededToAttack = 0;
        public float maximumDistanceNeededToAttack = 3;
    }

}
