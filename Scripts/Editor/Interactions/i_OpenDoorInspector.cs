using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    [CustomEditor(typeof(i_OpenDoor))]
    public class i_OpenDoorInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUILayout.BeginVertical("HelpBox");

            GUILayout.Label("Standard");
            i_OpenDoor interactableBase = (i_OpenDoor)target;

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

        public void BasicVariables(i_OpenDoor interactableBase)
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
        private void SpecialVariables(i_OpenDoor interactableBase)
        {
            interactableBase.setTriggerName = EditorGUILayout.TextField("Set Trigger Name",interactableBase.setTriggerName);
            interactableBase.needKey = EditorGUILayout.Toggle("Need Key", interactableBase.needKey);
            if(interactableBase.needKey)interactableBase.keyItem = (ItemScriptable)EditorGUILayout.ObjectField("Key Item", interactableBase.keyItem, typeof(ItemScriptable), allowSceneObjects: true);
        }
    }
}
