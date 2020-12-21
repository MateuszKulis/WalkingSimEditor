using System.Collections.Generic;
using UnityEngine;
using WalkingSim.Character;

namespace WalkingSim.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        public KeyCode keyToActive = KeyCode.I;

        [HideInInspector]public List<ItemScriptable> items;
        [HideInInspector]public ItemSlot[] itemSlots;
        public GameObject inventoryObject;
        public Transform itemsParent;

        private PlayerController playerController;

        private bool isActive = false;

        private void Awake()
        {
            playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(keyToActive)) isActive = !isActive;
            InventoryActive();
        }

        private void InventoryActive()
        {
            if (isActive)
            {
                inventoryObject.SetActive(true);
                playerController.blockMovment = true;
            }
            else
            {
                inventoryObject.SetActive(false);
                playerController.blockMovment = false;
            }
        }

        private void OnValidate()
        {
            if (itemsParent != null)
            {
                itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
                Refresh();
            }
        }

        private void Refresh()
        {
            int i = 0;
            for (; i < items.Count && i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = items[i];
            }

            for (;i < itemSlots.Length; i++)
            {
                itemSlots[i].Item = null;
            }
        }

        public bool AddItem(ItemScriptable _item)
        {
            if (IsFull())
                return false;

            items.Add(_item);
            Refresh();
            return true;
        }

        public bool RemoveItem(ItemScriptable _item)
        {
            if (items.Remove(_item))
            {
                Refresh();
                return true;
            }
            return false;
        }

        private bool IsFull()
        {
            return items.Count >= itemSlots.Length;
        }

    }
}
