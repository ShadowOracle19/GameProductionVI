using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class BlackFire : MonoBehaviour
    {
        public GameObject emitters;
        public int currentWeaponDamage = 25;
        public int effectRadius;
        public int range;
        public float aliveTime = 10f;

        public void Awake()
        {           
            StartCoroutine(expand());
        }
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                EnemyStats enemyStats = other.gameObject.GetComponent<EnemyStats>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);

                }
            }
        }

      

        IEnumerator expand()
        {
            
            yield return new WaitForSeconds(0.1f);
            for (float i = 0; i < effectRadius * 10; i++)
            {
                gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(effectRadius, effectRadius, effectRadius), 0.01f);

                yield return new WaitForSeconds(0.1f);
            }
            Destroy(gameObject, aliveTime);
            
        }


        
    }
}

