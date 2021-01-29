using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightWeapon;
        public WeaponItem leftWeapon;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();    

        }

        private void Start()
        {
            weaponSlotManager.loadWeaponOnSlot(rightWeapon, false);
            weaponSlotManager.loadWeaponOnSlot(leftWeapon, true);
        }
    }
}

