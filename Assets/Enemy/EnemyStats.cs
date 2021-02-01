using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class EnemyStats : CharacterStats
    {
        

        Animator animatorHandler;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<Animator>();

        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            
        }

        //change this level to balance what max health the player is per level
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            animatorHandler.Play("Damage_01");
            Debug.Log("Enemy damaged");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.Play("Death_01");
                //Handle player death
            }
        }
    }
}

