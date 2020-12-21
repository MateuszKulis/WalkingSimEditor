using UnityEngine;
using UnityEditor;

namespace WalkingSim.Inventory
{
    [CustomEditor(typeof(ItemScriptable))]
    public class ItemScriptableInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            ItemScriptable item = (ItemScriptable)target;

            GUILayout.BeginVertical("HelpBox");

            GUILayout.Label("Item Data");

            item.nameItem = EditorGUILayout.TextField("Name Item", item.nameItem);
            EditorGUILayout.Space();
            item.descriptionItem = EditorGUILayout.TextField("Description Item", item.descriptionItem, GUILayout.MaxHeight(75));
            EditorGUILayout.Space();
            item.iconItem = (Sprite)EditorGUILayout.ObjectField("Icon Item", item.iconItem, typeof(Sprite), allowSceneObjects: true);
            EditorGUILayout.Space();

            item.canDrop = EditorGUILayout.Toggle("Can Drop", item.canDrop);
            EditorGUILayout.Space();

            if (item.canDrop) item.prefabItem =  (GameObject)EditorGUILayout.ObjectField("Prefab Item", item.prefabItem, typeof(GameObject), allowSceneObjects: true);


            GUILayout.EndVertical();

            EditorUtility.SetDirty(item);

            serializedObject.ApplyModifiedProperties();

        }

    }
}
