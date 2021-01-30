using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LC
{
    public class WeaponPickup : Interactable
    {
        public WeaponItem weapon;

        public override void Interact(PlayerManager playerManager)
        {
            base.Interact(playerManager);

            //pick up weapon and add to players inventory
            PickUpItem(playerManager);
        }

        private void PickUpItem(PlayerManager playerManager)
        {
            PlayerInventory playerInventory;
            PlayerLocomotion playerLocomotion;
            AnimatorHandler animatorHandler;
            playerInventory = playerManager.GetComponent<PlayerInventory>();
            playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
            animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();

            Debug.Log("Pick up");

            playerLocomotion.rigidbody.velocity = Vector3.zero;//stops player from moving when picking up item
            animatorHandler.PlayTargetAnimation("Pick Up Item", true); //plays animation of looting the item
            playerInventory.weaponsInventory.Add(weapon);
            playerManager.itemInteractableGameobject.GetComponentInChildren<Text>().text = weapon.itemName;
            playerManager.itemInteractableGameobject.GetComponentInChildren<RawImage>().texture = weapon.itemIcon.texture;
            playerManager.itemInteractableGameobject.SetActive(true);
            Destroy(gameObject);

        }
    }
}

