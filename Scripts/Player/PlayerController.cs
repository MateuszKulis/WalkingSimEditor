using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalkingSim.Character
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerData playerData;

        [HideInInspector] public Camera mainCamera;
        [HideInInspector]public bool blockMovment = false;

        private CharacterController controller;

        private void Awake()
        {
            controller = GetComponentInChildren<CharacterController>();
            mainCamera = GetComponentInChildren<Camera>();
            Cursor.lockState = CursorLockMode.Locked;
            deafultPosY = controller.height / 2;
        }

        void Update()
        {
            if (!blockMovment)
            {
                Movment();
                Gravity();
                Jump();
                MouseLook();
            }
        }

        private void Movment()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;

            if (Input.GetKey(KeyCode.LeftShift) && playerData.canRun)
                Run(move);
            else
                controller.Move(move * playerData.walkSpeed * Time.deltaTime);

            if(playerData.isHeadBobbing)HeadBobbing(move);

        }

        private void Run(Vector3 _move) { controller.Move(_move * playerData.runSpeed * Time.deltaTime); }

        float deafultPosY;
        float timer = 0f;
        private void HeadBobbing(Vector3 _move)
        {
            float waveslice = 0.0f;
            Vector3 cameraPos = mainCamera.transform.localPosition;
            if (Mathf.Abs(_move.x) == 0 && Mathf.Abs(_move.z) == 0)
            {
                timer = 0.0f;
            }
            else
            {
                waveslice = Mathf.Sin(timer);
                timer = timer + playerData.walkBobbingSpeed/100f;
                if (timer > Mathf.PI * 2)
                {
                    timer = timer - (Mathf.PI * 2);
                }
            }
            if (waveslice != 0)
            {
                float translateChange = waveslice * playerData.bobbingAmount/10f;
                float totalAxes = Mathf.Abs(_move.x) + Mathf.Abs(_move.z);
                totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
                translateChange = totalAxes * translateChange;
                cameraPos.y = deafultPosY + translateChange;
            }
            else
            {
                cameraPos.y = deafultPosY;
            }

            mainCamera.transform.localPosition = cameraPos;
        }
        
        Vector3 velocity;
        private void Gravity()
        {
            velocity.y += -playerData.gravityForce * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            if (CanJump() && velocity.y < 0) velocity.y = -2f;
        }

        private bool CanJump()
        {
            RaycastHit hit;
            return (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, controller.height/2 + 0.1f) && Input.GetKeyDown(KeyCode.Space) && playerData.canJump);
        }

        private void Jump()
        {
            if (CanJump()) velocity.y = Mathf.Sqrt(playerData.jumpHeight * -2f * -playerData.gravityForce);
        }

        float xRotation;
        private void MouseLook()
        {
            float mouseX = Input.GetAxis("Mouse X") * playerData.mouseSensitivity * 100f * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * playerData.mouseSensitivity * 100f * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

    }

}
