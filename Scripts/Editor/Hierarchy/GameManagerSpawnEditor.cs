using UnityEditor;
using UnityEngine;

namespace WalkingSim.Inspector
{
    public class GameManagerSpawnEditor : EditorWindow
    {

        [MenuItem("GameObject/WalkingSimEditor/Game Manager", priority = 1)]
        public static void SpawnPlayer()
        {
            Object gameManager = AssetDatabase.LoadAssetAtPath("Assets/Components/GameManager.prefab", typeof(GameObject));
            if (gameManager != null)
            {
                PrefabUtility.InstantiatePrefab(gameManager);
            }
        }
    }
}