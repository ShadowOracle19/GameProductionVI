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

        public void DoPush()
        {
            var shield = Instantiate(forceFieldPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
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
            for (float i = 0; i < 10; i++)
            {
                shield.transform.localScale += new Vector3(i, i, i);
                yield return new WaitForSeconds(0.01f);
            }


            yield return new WaitForSeconds(1.0f);
            for (float i = 0; i < 10; i++)
            {
                j -= 1;
                shield.transform.localScale -= new Vector3(j, j, j);
                yield return new WaitForSeconds(0.007f);
            }
            //PlayerAnimator.SetInteger("AnimController", 0);
            Destroy(shield);
            yield return new WaitForSeconds(0.001f);

        }

    }

}
