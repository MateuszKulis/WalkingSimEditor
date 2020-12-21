using UnityEngine;

namespace WalkingSim.Interactions
{
    public interface IInteractable
    {
        float HoldDuration { get; }

        bool HoldInteract { get; }
        bool IsInteractable { get; }

        void OnInteract();
    }
}
