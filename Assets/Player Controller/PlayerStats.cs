using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class PlayerStats : CharacterStats
    {
        PlayerManager playerManager;

        HealthBar healthBar;
        StaminaBar staminaBar;

        AnimatorHandler animatorHandler;

        public float staminaRegenerationAmount = 1;
        public float staminaRegenerationTimer = 0;
        public Transform spawnPoint;
        public Transform playerTransform;
        public AudioSource playerAudio;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            healthBar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            staminaBar.SetMaxStamina(maxStamina);
        }

        //change this level to balance what max health the player is per level
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private float SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            if (playerManager.isInvulnerable)
                return;

            if (isDead)
                return;

            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Death_01", true);
                isDead = true;
                //Handle player death
                StartCoroutine(respawnPlayer());
            }
        }

        IEnumerator respawnPlayer()
        {
            yield return new WaitForSeconds(2f);

            RespawnPlayer();
            yield return new WaitForSeconds(0.1f);
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void RegenerateStamina()
        {
            if(playerManager.isInteracting)
            {
                staminaRegenerationTimer = 0;
            }
            else
            {
                staminaRegenerationTimer += Time.deltaTime;
                if (currentStamina < maxStamina && staminaRegenerationTimer > 1f)
                {
                    currentStamina += staminaRegenerationAmount * Time.deltaTime;
                    staminaBar.SetCurrentStamina(Mathf.RoundToInt(currentStamina));
                }
            }

            
        }
        
        public void HealPlayer(int healAmount)
        {
            currentHealth = currentHealth + healAmount;

            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            healthBar.SetCurrentHealth(currentHealth);
        }

        public void RespawnPlayer()
        {
            playerTransform.position = spawnPoint.position;
            isDead = false;

            currentHealth = maxHealth;
            healthBar.SetCurrentHealth(currentHealth);
        }
        
    }
}

