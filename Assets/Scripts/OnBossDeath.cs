using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class OnBossDeath : MonoBehaviour
    {
        public EnemyStats enemyStats;
        public GameObject exitPlate;
        bool active = true;
        // Update is called once per frame
        void Update()
        {
            if(enemyStats.isDead && active)
            {
                exitPlate.SetActive(true);
            }
        }
    }
}

