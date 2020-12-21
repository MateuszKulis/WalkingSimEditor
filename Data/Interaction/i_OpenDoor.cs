using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    public class i_OpenDoor : InteractableBase
    {
        public string setTriggerName = "Open";
        public bool needKey;
        public ItemScriptable keyItem;

        public override void OnInteract()
        {
            base.OnInteract();

            if (needKey)
            {
                if (InteractionController._isInventory)
                {
                    if (InteractionController._inventoryController.RemoveItem(keyItem))
                    {
                        Animator anim = GetComponent<Animator>();
                        anim.SetTrigger(setTriggerName);
                        isInteractable = false;
                    }
                }
            }
            else
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger(setTriggerName);
                isInteractable = false;
            }
        }

    }
}
