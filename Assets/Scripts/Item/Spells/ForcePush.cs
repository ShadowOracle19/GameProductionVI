using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC
{
    public class ForcePush : MonoBehaviour
    {
        public float pushAmount = 1000;
        public float pushRadius = 10;
        public int damage = 10;

        public GameObject forceFieldPrefab;
        private Vector3 scaleChange = new Vector3(0f, 0f, 0f);

        public void Awake()
        {
            var shield = forceFieldPrefab;
            shield.transform.localScale = scaleChange;
            Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

            foreach (Collider pushedObjec in colliders)
            {
                if (pushedObjec.CompareTag("Enemy"))
                {
                    pushedObjec.GetComponent<EnemyStats>().TakeDamage(damage);
                }
            }
            StartCoroutine(grow(shield));
        }

        
        IEnumerator grow(GameObject shield)
        {
            float j = 10;
            yield return new WaitForSeconds(0.1f);
            for (float i = 0; i < pushRadius; i++)
            {
                gameObject.transform.localScale += new Vector3(i, i, i);
                yield return new WaitForSeconds(0.05f);
            }


            Destroy(gameObject);
            

            yield return new WaitForSeconds(0.001f);

        }

    }

}
