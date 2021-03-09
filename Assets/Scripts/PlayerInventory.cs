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
        

        public int currentRightWeaponIndex = 1;
        int tempWeaponIndex;
        public bool isMeleeWeaponEquipped;

        public List<WeaponItem> weaponsInventory;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
            
        }

        private void Start()
        {
            
            rightWeapon = weaponsInRightHandSlots[1];
            
            weaponSlotManager.loadWeaponOnSlot(rightWeapon, false);
           
            
        }

        public void ChangeRightWeapon()
        {
            currentRightWeaponIndex += 1;

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
                case 1:
                    if(weaponsInRightHandSlots[0] != null)
                    {
                        isMeleeWeaponEquipped = false;
                        tempWeaponIndex = currentRightWeaponIndex;
                        rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                        weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                    }
                    break;
                case 2:
                    if (weaponsInRightHandSlots[0] != null)
                    {
                        isMeleeWeaponEquipped = false;
                        tempWeaponIndex = currentRightWeaponIndex;
                        rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                        weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                    }
                    break;
                case 3:
                    if (weaponsInRightHandSlots[0] != null)
                    {
                        isMeleeWeaponEquipped = false;
                        tempWeaponIndex = currentRightWeaponIndex;
                        rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                        weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                    }
                    break;
                default:
                    currentRightWeaponIndex = 0;
                    tempWeaponIndex = currentRightWeaponIndex;
                    break;
            }
        }

        public void UseMeleeWeapon()
        {
            isMeleeWeaponEquipped = true;
            currentRightWeaponIndex = 0;
            if (weaponsInRightHandSlots[0] != null)
            {
                rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
            }
        }

        public void UnequipMeleeWeapon()
        {
            if(isMeleeWeaponEquipped)
            {
                Debug.Log(tempWeaponIndex);
                isMeleeWeaponEquipped = false;
                currentRightWeaponIndex = tempWeaponIndex;
                if (weaponsInRightHandSlots[0] != null)
                {
                    rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                    weaponSlotManager.loadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                }
            }
            
        }
        
    }
}

