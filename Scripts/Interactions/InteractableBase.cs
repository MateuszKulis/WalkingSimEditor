using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    public class InteractableBase : MonoBehaviour,
    IInteractable
    {
        #region variables


        public bool holdInteract = true;
        public float holdDuration = 1f;

        public bool isInteractable = true;

        public bool setText = true;
        public string interactText = "Use";
        #endregion

        #region Properties
        public float HoldDuration => holdDuration;

        public bool HoldInteract => holdInteract;
        public bool IsInteractable => isInteractable;
        #endregion

        #region Methods
        public virtual void OnInteract()
        {

        }

        #endregion
    }

}
