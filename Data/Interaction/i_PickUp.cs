using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    public class i_PickUp : InteractableBase
    {
        public ItemScriptable item;
        public int amount;

        public override void OnInteract()
        {
            base.OnInteract();
            Destroy(gameObject);
            if(InteractionController._isInventory)InteractionController._inventoryController.AddItem(item);
        }
    }
}
