using UnityEngine;
using UnityEngine.UI;

namespace WalkingSim.Inventory
{
    public class ItemSlot : MonoBehaviour
    {
        [HideInInspector]public Image image;

        private ItemScriptable _item;
        public ItemScriptable Item
        {
            get { return _item; }
            set
            {
                _item = value;

                if (_item == null)
                {
                    image.enabled = false;
                }
                else
                {
                    image.enabled = true;
                    image.sprite = _item.iconItem;
                }
            }
        }

        private void OnValidate()
        {
            if (image == null)
                image = GetComponent<Image>();
        }
    }
}
