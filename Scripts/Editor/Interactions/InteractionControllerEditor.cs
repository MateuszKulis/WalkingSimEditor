using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    [CustomEditor(typeof(InteractionController))]
    public class InteractionControllerEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            base.OnInspectorGUI();

            InteractionController interactionController = (InteractionController)target;

            interactionController.rayDistance = EditorGUILayout.Slider("Ray Distance", interactionController.rayDistance, 0.5f, 15f);
            interactionController.raySphareRadius = EditorGUILayout.Slider("Ray Radius", interactionController.raySphareRadius, 0.1f, 0.9f);


            interactionController.isNormalText = EditorGUILayout.Toggle("Is Normal Text", interactionController.isNormalText);
            if (interactionController.isNormalText) interactionController.isProText = false;
            if (interactionController.isNormalText && !interactionController.isProText)
            {
                interactionController.deafultText = EditorGUILayout.TextField(interactionController.deafultText);
                interactionController.interactText = (Text)EditorGUILayout.ObjectField("Text Object", interactionController.interactText, typeof(Text), allowSceneObjects:true);
                EditorGUILayout.Space();
            }
            interactionController.isProText = EditorGUILayout.Toggle("Is Pro Text", interactionController.isProText);
            if (interactionController.isProText) interactionController.isNormalText = false;
            if (interactionController.isProText && !interactionController.isNormalText)
            {
                interactionController.deafultTextPro = EditorGUILayout.TextField(interactionController.deafultTextPro);
                interactionController.interactTextPro = (TextMeshProUGUI)EditorGUILayout.ObjectField("Text Object", interactionController.interactTextPro, typeof(TextMeshProUGUI), allowSceneObjects: true);
                EditorGUILayout.Space();
            }
            interactionController.isProgressBar = EditorGUILayout.Toggle("Is Progress Bar", interactionController.isProgressBar);
            if (interactionController.isProgressBar)
            {
                interactionController.progressBar = (Image)EditorGUILayout.ObjectField("Text Object", interactionController.progressBar, typeof(Image), allowSceneObjects: true);

            }

            interactionController.isInventory = EditorGUILayout.Toggle("Is Inventory", interactionController.isInventory);
            if (interactionController.isInventory)
            {
                interactionController.inventoryController = (InventoryController)EditorGUILayout.ObjectField("Inventory Controller", interactionController.inventoryController, typeof(InventoryController), allowSceneObjects: true);
            }

            EditorUtility.SetDirty(interactionController);

            serializedObject.ApplyModifiedProperties();

        }
    }
}
