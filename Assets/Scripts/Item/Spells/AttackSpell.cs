using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC
{
    [CreateAssetMenu(menuName = "Spells/Attacking Spell")]
    public class AttackSpell : SpellItem
    {
        public int damage;

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animatorHandler.transform);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);
        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, animatorHandler.transform);
        }
    }
}

