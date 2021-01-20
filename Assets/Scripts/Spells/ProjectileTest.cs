using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTest : MonoBehaviour
{
    public float pushAmount;
    public float pushRadius;
    private bool collided = false;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            Destroy(gameObject);  
        }
        else if(collision.gameObject.tag == "Enemy" && !collided)
        {
            DoPush();
        }
    }
    void Update()
    {
        transform.Rotate(1f, 1f, 1f); // Let's try spinning, that's a good trick...
    }

    private void DoPush()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

        foreach(Collider pushedObjec in colliders)
        {
            if(pushedObjec.CompareTag("Enemy"))
            {
                Rigidbody pushedBody = pushedObjec.GetComponent<Rigidbody>();

                pushedBody.AddExplosionForce(pushAmount, gameObject.transform.position, pushRadius);
                collided = true;
                Destroy(gameObject);
            }
        }
    }
}
