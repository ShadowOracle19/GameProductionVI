using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotSpeed = 1.0f; // Inspector will always override this. Public because we could change this upon spawn.

    public int startingHealth = 5;

    private int currentHealth;

    void Start()
    {
        EnemyManager.instance.enemies.Add(this);
        currentHealth = startingHealth;
    }

    void Update()
    {
        //transform.Rotate(0, rotSpeed, 0); // Let's try spinning, that's a good trick...
    }

    public void takeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        EnemyManager.instance.EnemyAlive = false;
        Destroy(this);
    }

    
}
