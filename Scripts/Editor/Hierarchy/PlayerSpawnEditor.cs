using UnityEditor;
using UnityEngine;

namespace WalkingSim.Inspector
{
    public class PlayerSpawnEditor : EditorWindow
    {

        [MenuItem("GameObject/WalkingSimEditor/Player Controller", priority = 0)]
        public static void SpawnPlayer()
        {
            Object playerPrefab = AssetDatabase.LoadAssetAtPath("Assets/Components/PlayerController.prefab", typeof(GameObject));
            if (playerPrefab != null)
            {
                PrefabUtility.InstantiatePrefab(playerPrefab);
            }
        }
    }
}