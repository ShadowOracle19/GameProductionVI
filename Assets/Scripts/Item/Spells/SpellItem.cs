using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC
{
    public class SpellItem : Item
    {
        public GameObject spellWarmUpFX;
        public GameObject spellCastFX;

        public string spellAnimation;



        [Header("Spell Description")]
        [TextArea]
        public string spellDescription;

        [Header("Spell Attributes")]
        public int damage;
        public float range;
        public float effectRadius;
        public float projectileSpeed = 30f;
        public Vector3 destination;
        public bool isAoe;
        private Vector3 weaponSlot;
        public int cost;
        public virtual void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            Debug.Log("attempt to cast");
        }

        public virtual void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponHolderSlot)
        {
            Debug.Log("Cast spell");
        }
    }

}
