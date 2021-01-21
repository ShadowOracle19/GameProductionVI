using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotSpeed = 1.0f; // Inspector will always override this. Public because we could change this upon spawn.

    public int startingHealth = 5;

    private int currentHealth;

    public Material dissolveEffect;

    public float TimeSinceStart = 0;
    public bool isDying = false;

    void Start()
    {
        EnemyManager.instance.enemies.Add(this);
        currentHealth = startingHealth;
    }

    void Update()
    {
        if(isDying)
        {
            GetComponent<MeshRenderer>().material.SetFloat("Vector1_CE7AAB4D", TimeSinceStart);
            TimeSinceStart += Time.deltaTime;
        }
        
        //transform.Rotate(0, rotSpeed, 0); // Let's try spinning, that's a good trick...
    }

    public void takeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    

    IEnumerator Die()
    {
        
        this.GetComponent<MeshRenderer>().material = dissolveEffect;
        isDying = true;
        yield return new WaitForSeconds(3.0f);
        EnemyManager.instance.EnemyAlive = false;
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);
    }
    
}
