using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class BlackFire : MonoBehaviour
    {
        public int currentWeaponDamage = 25;

        

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Enemy")
            {
                EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                    
                }
            }
        }
    }
}

