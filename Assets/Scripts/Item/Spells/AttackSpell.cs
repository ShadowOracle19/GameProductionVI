using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LC
{
    [CreateAssetMenu(menuName = "Spells/Attacking Spell")]
    public class AttackSpell : SpellItem
    {
        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats)
        {
            if (cost > playerStats.currentStamina)
                return;
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animatorHandler.transform);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);
            Destroy(instantiatedWarmUpSpellFX, 5);
        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponHolderSlot)
        {
            if (cost > playerStats.currentStamina)
                return;
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, weaponHolderSlot.rightHandSlot.transform.position, Quaternion.identity);
            playerStats.TakeStaminaDamage(cost);
            if (!isAoe)
            {
                
                Debug.DrawRay(weaponHolderSlot.rightHandSlot.transform.position, Camera.main.transform.forward * range, Color.red, 2f);
                
                Ray ray = new Ray(weaponHolderSlot.rightHandSlot.transform.position, Camera.main.transform.forward * range);
                

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    destination = hit.point;
                }
                else
                {
                    destination = ray.GetPoint(range);
                }

                instantiatedSpellFX.GetComponent<Rigidbody>().velocity = (destination - weaponHolderSlot.rightHandSlot.transform.position).normalized * projectileSpeed;

            }
            
        }
    }

    
}

