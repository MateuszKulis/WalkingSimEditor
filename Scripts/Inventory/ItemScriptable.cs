using UnityEngine;

namespace WalkingSim.Inventory
{
    [CreateAssetMenu(fileName = "Item Name", menuName = "Data/Inventory/Item")]
    public class ItemScriptable : ScriptableObject
    {
        public string nameItem;
        public string descriptionItem;
        public Sprite iconItem;
        public bool canDrop;
        public GameObject prefabItem;
    }
}