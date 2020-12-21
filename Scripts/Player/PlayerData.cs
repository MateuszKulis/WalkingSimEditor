using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WalkingSim.Character
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Data/Character/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public float mouseSensitivity = 15f;
        public float walkSpeed = 9f;
        public bool canRun = true;
        public float runSpeed = 12f;
        public bool isHeadBobbing = true;
        public float walkBobbingSpeed = 2f;
        public float bobbingAmount = 1.5f;
        public bool canJump = true;
        public float jumpHeight = 2.5f;
        public float gravityForce = 30f;


        public bool isSave;
        public float _mouseSensitivity;
        public float _walkSpeed;
        public bool _canRun;
        public float _runSpeed;
        public bool _isHeadBobbing;
        public float _walkBobbingSpeed;
        public float _bobbingAmount;
        public bool _canJump;
        public float _jumpHeight;
        public float _gravityForce;

    }
}
