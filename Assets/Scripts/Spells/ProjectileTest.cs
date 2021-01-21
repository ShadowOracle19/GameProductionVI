using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTest : MonoBehaviour
{
    public GameObject impactVFX;
    public float pushAmount;
    public float pushRadius;
    private bool collided = false;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collided)
        {
            
            collided = true;
            collision.gameObject.GetComponent<Enemy>().takeDamage(5);
            var impact = Instantiate(impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            
            var impact = Instantiate(impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 1);
            Destroy(gameObject);  
        }
        
        
    }
    void Update()
    {
        transform.Rotate(1f, 1f, 1f); // Let's try spinning, that's a good trick...
    }

    
}
