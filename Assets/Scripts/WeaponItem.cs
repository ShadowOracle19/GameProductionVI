using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    [CreateAssetMenu(menuName ="Item/Weapon Item")]
    public class WeaponItem : Item
    {
        public GameObject modelPrefab;
        public bool isUnarmed;
        public SpellItem spell;

        [Header("Idle Animations")]
        public string right_Hand_Idle;
        public string th_idle;

        [Header("One Handed Attack Animations")]
        public string OH_Light_Attack_1;
        public string OH_Light_Attack_2;
        public string OH_Heavy_Attack_1;
        public string TH_Light_Attack_1;
        public string TH_Light_Attack_2;
        public string TH_Heavy_Attack_1;

        [Header("Stamina Cost")]
        public int baseStamina;
        public float lightAttackMultiplyer;
        public float heavyAttackMultiplier;

        [Header("Weapon Type")]
        public bool isSpellCaster;
        public bool isFaithCaster;
        public bool isPyroCaster;
        public bool isMeleeWeapon;
    }
}

