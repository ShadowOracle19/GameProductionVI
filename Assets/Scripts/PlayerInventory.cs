using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public SpellItem currentSpell;
        public WeaponItem rightWeapon;
        
        public WeaponItem unarmedWeapon;
        public WeaponItem meleeWeapon;

        public WeaponItem[] weaponsInRightHandSlots = new WeaponItem[1];
        

        public int currentRightWeaponIndex = -1;
        

        public List<WeaponItem> weaponsInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
            
        }

        private void Start()
        {
            
            rightWeapon = weaponsInRightHandSlots[0];
            
            weaponSlotManager.loadWeaponOnSlot(rightWeapon, false);
           
            
        }

        public void ChangeRightWeapon()
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;

            //if(currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] != null)
            //{
            //    rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            //    weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
            //}

            //else if (currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] == null)
            //{
            //    currentRightWeaponIndex = currentRightWeaponIndex + 1;
            //}

            //else if(currentRightWeaponIndex == 1 && weaponsInRightHandSlots[1] != null)
            //{
            //    rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            //    weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
            //}
            //else
            //{
            //    currentRightWeaponIndex = currentRightWeaponIndex + 1;
            //}

            switch (currentRightWeaponIndex)
            {
                case 0:
                    if(weaponsInRightHandSlots[0] != null)
                    {
                        rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                        weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                    }
                    break;

                case 1:
                    if (weaponsInRightHandSlots[0] != null)
                    {
                        rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                        weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                    }
                    break;
                default:
                    currentRightWeaponIndex = 0;
                    break;
            }

            //if(currentRightWeaponIndex > weaponsInRightHandSlots.Length - 1)
            //{
            //    currentRightWeaponIndex = -1;
            //    rightWeapon = unarmedWeapon;
            //    weaponSlotManager.loadWeaponOnSlot(unarmedWeapon, false);
            //}
        }

        public void UseMeleeWeapon()
        {
            rightWeapon = meleeWeapon;
            weaponSlotManager.loadWeaponOnSlot(meleeWeapon, false);
        }

        public void UnequipMeleeWeapon()
        {
            rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
            weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
        }
        
    }
}

