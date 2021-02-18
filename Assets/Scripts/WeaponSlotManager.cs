using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class WeaponSlotManager : MonoBehaviour
    {
        PlayerManager playerManager;
        public WeaponItem attackingWeapon;
        
        WeaponHolderSlot rightHandSlot;
        WeaponHolderSlot sideSlot;
        DamageCollider rightHandDamageCollider;

        

        Animator animator;

        QuickSlotsUI quickSlotsUI;

        PlayerStats playerStats;
        InputHandler inputHandler;

        private void Awake()
        {
            playerManager = GetComponentInParent<PlayerManager>();
            animator = GetComponent<Animator>();
            quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
            playerStats = GetComponentInParent<PlayerStats>();
            inputHandler = GetComponentInParent<InputHandler>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {

                if(weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
                
                else if(weaponSlot.isBackSlot)
                {
                    sideSlot = weaponSlot;
                }
            }
        }

        public void loadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            
            if (isLeft == false)
            {

                    #region handle right weapon Idle animations

                    animator.CrossFade("Both Arms Empty", 0.2f);

                    sideSlot.UnloadWeaponAndDestroy();

                    if (weaponItem != null)
                    {
                        animator.CrossFade(weaponItem.right_Hand_Idle, 0.2f);
                    }
                    else
                    {
                        animator.CrossFade("Right Arm Empty", 0.2f);
                    }
                    #endregion
                
                rightHandSlot.currentWeapon = weaponItem;
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(false, weaponItem);


            }
        }

        #region Handle Weapon's Damage Collider

        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenDamageCollider()
        {           
            if(playerManager.isUsingRightHand)
            {
                rightHandDamageCollider.EnableDamageCollider();
            }
            
        }     
        public void CloseDamageCollider()
        {
            rightHandDamageCollider.DisableDamageCollider();
            
        }

        #endregion

        #region handle weapon stamina drainage
        public void DrainStaminaLightAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplyer));
        }
        public void DrainStaminaHeavyAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
        }
        #endregion
    }
}

