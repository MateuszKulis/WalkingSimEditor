using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    [CustomEditor(typeof(i_PickUp))]
    public class i_PickUpInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUILayout.BeginVertical("HelpBox");

            GUILayout.Label("Standard");
            i_PickUp interactableBase = (i_PickUp)target;

            BasicVariables(interactableBase);
            GUILayout.EndVertical();
            EditorGUILayout.Space();
            GUILayout.BeginVertical("HelpBox");

            GUILayout.Label("Special");
            if (interactableBase.isInteractable)SpecialVariables(interactableBase);
            GUILayout.EndVertical();
            EditorUtility.SetDirty(interactableBase);
            serializedObject.ApplyModifiedProperties();
        }

        public void BasicVariables(i_PickUp interactableBase)
        {
            interactableBase.isInteractable = EditorGUILayout.Toggle("Is Interactable", interactableBase.isInteractable);

            if (interactableBase.isInteractable)
            {
                interactableBase.holdInteract = EditorGUILayout.Toggle("Hold Interact", interactableBase.holdInteract);
                if (interactableBase.holdInteract) interactableBase.holdDuration = EditorGUILayout.Slider("Hold Duration", interactableBase.holdDuration, 0.1f, 10f);
                interactableBase.setText = EditorGUILayout.Toggle("Set Text", interactableBase.setText);
                if (interactableBase.setText) interactableBase.interactText = EditorGUILayout.TextField(interactableBase.interactText);
            }
            EditorGUILayout.Space();
        }
        private void SpecialVariables(i_PickUp interactableBase)
        {
            interactableBase.item = (ItemScriptable)EditorGUILayout.ObjectField("Item", interactableBase.item, typeof(ItemScriptable), allowSceneObjects: true);
            interactableBase.amount = EditorGUILayout.IntSlider("Amount", interactableBase.amount, 1, 99);
        }
    }
}
