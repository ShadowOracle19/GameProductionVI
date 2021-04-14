using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC
{
    [CreateAssetMenu(menuName = "Spells/Healing Spell")]
    public class HealingSpell : SpellItem
    {
        public int healAmount;

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            if (cost > playerStats.currentStamina)
                return;
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animatorHandler.transform);           
            animatorHandler.PlayTargetAnimation(spellAnimation, true);
            Destroy(instantiatedWarmUpSpellFX, 1);
            //spellSFX.Play();
            playerStats.playerAudio.clip = spellSFX;
            playerStats.playerAudio.Play();
        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponHolderSlot)
        {
            if (cost > playerStats.currentStamina)
                return;
            playerStats.TakeStaminaDamage(cost);
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, weaponHolderSlot.rightHandSlot.transform);
            playerStats.HealPlayer(healAmount);
            Destroy(instantiatedSpellFX, 1);
        }
    }
}

