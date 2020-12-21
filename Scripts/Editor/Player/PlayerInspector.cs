using UnityEngine;
using UnityEditor;

namespace WalkingSim.Character
{

    [CustomEditor(typeof(PlayerData))]
    public class PlayerInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            PlayerData playerData = (PlayerData)target;


            GUILayout.Label("Player Data");

            playerData.mouseSensitivity = EditorGUILayout.Slider("Mouse Sensitivity", playerData.mouseSensitivity, 2f, 20f);

            playerData.walkSpeed = EditorGUILayout.Slider("Walk Speed", playerData.walkSpeed, 1f, 20f);

            playerData.canRun = EditorGUILayout.Toggle("Can Run", playerData.canRun);
            if (playerData.canRun) playerData.runSpeed = EditorGUILayout.Slider("Run Speed", playerData.runSpeed, playerData.walkSpeed, 30f);

            playerData.isHeadBobbing = EditorGUILayout.Toggle("Head Bobbing", playerData.isHeadBobbing);
            if (playerData.isHeadBobbing) playerData.walkBobbingSpeed = EditorGUILayout.Slider("Speed", playerData.walkBobbingSpeed, 1f, 5f);
            if (playerData.isHeadBobbing) playerData.bobbingAmount = EditorGUILayout.Slider("Amount", playerData.bobbingAmount, 1f, 5f);
            if (playerData.isHeadBobbing) EditorGUILayout.Space();

            playerData.gravityForce = EditorGUILayout.Slider("Gravity Force", playerData.gravityForce, 5f, 35f);


            playerData.canJump = EditorGUILayout.Toggle("Can Jump", playerData.canJump);
            if (playerData.canJump) playerData.jumpHeight = EditorGUILayout.Slider("Jump Height", playerData.jumpHeight, 0f, 10f);

            EditorGUILayout.Space();
            if (GUILayout.Button("Set Deafult Settings"))
            {
                playerData.mouseSensitivity = 15f;
                playerData.walkSpeed = 9f;
                playerData.runSpeed = 12f;
                playerData.walkBobbingSpeed = 2f;
                playerData.bobbingAmount = 1.5f;
                playerData.gravityForce = 30f;
                playerData.jumpHeight = 2.5f;

                playerData.canJump = true;
                playerData.canRun = true;
                playerData.isHeadBobbing = true;
            }
            EditorGUILayout.Space();
            if (GUILayout.Button("Load Settings"))
            {
                playerData.mouseSensitivity = playerData._mouseSensitivity;
                playerData.walkSpeed = playerData._walkSpeed;
                playerData.runSpeed = playerData._runSpeed;
                playerData.walkBobbingSpeed = playerData._walkBobbingSpeed;
                playerData.bobbingAmount = playerData._bobbingAmount;
                playerData.gravityForce = playerData._gravityForce;
                playerData.jumpHeight = playerData._jumpHeight;

                playerData.canJump = playerData._canJump;
                playerData.canRun = playerData._canRun;
                playerData.isHeadBobbing = playerData._isHeadBobbing;
            }
            EditorGUILayout.Space();
            if (GUILayout.Button("Save Settings"))
            {
                playerData._mouseSensitivity = playerData.mouseSensitivity;
                playerData._walkSpeed = playerData.walkSpeed;
                playerData._runSpeed = playerData.runSpeed;
                playerData._walkBobbingSpeed = playerData.walkBobbingSpeed;
                playerData._bobbingAmount = playerData.bobbingAmount;
                playerData._gravityForce = playerData.gravityForce;
                playerData._jumpHeight = playerData.jumpHeight;

                playerData._canJump = playerData.canJump;
                playerData._canRun = playerData.canRun;
                playerData._isHeadBobbing = playerData.isHeadBobbing;

                playerData.isSave = true;



                EditorUtility.SetDirty(playerData);

            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
