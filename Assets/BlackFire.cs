using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class BlackFire : MonoBehaviour
    {
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
            Destroy(gameObject, aliveTime);
            yield return new WaitForSeconds(0.1f);
            for (float i = 0; i < effectRadius; i++)
            {
                gameObject.transform.localScale += new Vector3(i, i, i);
                yield return new WaitForSeconds(0.1f);
            }
            

        }
    }
}

