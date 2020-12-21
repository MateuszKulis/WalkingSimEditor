using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using WalkingSim.Character;
using WalkingSim.Inventory;

namespace WalkingSim.Interactions
{
    public class InteractionController : MonoBehaviour
    {
        public KeyCode keyToInteract = KeyCode.E;

        [HideInInspector]public float rayDistance = 5f;
        [HideInInspector] public float raySphareRadius = 0.3f;

        [HideInInspector] public bool isNormalText = false;
        [HideInInspector] public Text interactText;
        [HideInInspector] public string deafultText = "Use";

        [HideInInspector] public bool isProText = true;
        [HideInInspector] public TextMeshProUGUI interactTextPro;
        [HideInInspector] public string deafultTextPro = "Use";

        [HideInInspector] public bool isProgressBar = true;
        [HideInInspector] public Image progressBar;

        [HideInInspector] public bool isInventory = false;
        [HideInInspector] public InventoryController inventoryController;
        public static bool _isInventory = false;
        public static InventoryController _inventoryController;

        private PlayerController playerController;

        private void Awake()
        {
            playerController = FindObjectOfType<PlayerController>();
            if (isInventory)
            {
                inventoryController = transform.GetComponent<InventoryController>();
                _inventoryController = inventoryController;
                _isInventory = isInventory;
            }
        }

        void Update()
        {
            CheckForInteractable();
        }

        float timer;
        bool isClicked;
        private void CheckForInteractable()
        {
            Ray _ray = new Ray(playerController.mainCamera.transform.position, playerController.mainCamera.transform.forward);
            RaycastHit _hitInfo;

            bool _isHit = Physics.SphereCast(_ray, raySphareRadius, out _hitInfo, rayDistance);

            if (_isHit)
            {
                InteractableBase _interactable = _hitInfo.transform.GetComponent<InteractableBase>();

                if (_interactable)
                {
                    if (_interactable.isInteractable)
                    {
                        if (isNormalText)
                            SetNormalText(_interactable);
                        else if (isProText)
                            SetProText(_interactable);

                        if (_interactable.holdInteract)
                        {
                            if (InteractClicked())
                            {
                                playerController.blockMovment = true;

                                timer += Time.deltaTime;

                                float _holdPercent = timer / _interactable.holdDuration;
                                if(isProgressBar)UpdateProgressBar(_holdPercent);

                                if (timer >= _interactable.holdDuration)
                                {
                                    _interactable.OnInteract();

                                    playerController.blockMovment = false;

                                    timer = 0;
                                    ResetProgressBar();
                                }
                            }
                            if (InteractRelase())
                            {
                                playerController.blockMovment = false;

                                timer = 0;
                                ResetProgressBar();
                            }
                        }
                        else
                        {
                            if (InteractClick()) _interactable.OnInteract();
                        }
                    }
                    else
                        ResetText();
                }
                else
                    ResetText();
            }
            else
                ResetText();
        }

        private void SetNormalText(InteractableBase _interactable)
        {
            interactText.gameObject.SetActive(true);
            if (_interactable.setText)
                interactText.text = _interactable.interactText;
            else
                interactText.text = deafultText;
        }

        private void SetProText(InteractableBase _interactable)
        {
            interactTextPro.gameObject.SetActive(true);
            if (_interactable.setText)
                interactTextPro.text = _interactable.interactText;
            else
                interactTextPro.text = deafultText;
        }

        private void ResetText()
        {
            if(isNormalText)interactText.gameObject.SetActive(false);
            if(isProText)interactTextPro.gameObject.SetActive(false);
            if (isNormalText) interactText.text = "";
            if (isProText) interactTextPro.text = "";
            if(isProgressBar)ResetProgressBar();
        }
        public void ResetProgressBar() { progressBar.fillAmount = 0; progressBar.gameObject.SetActive(false); }

        public void UpdateProgressBar(float _fillAmount) { progressBar.fillAmount = _fillAmount; progressBar.gameObject.SetActive(true); }

        private bool InteractClick() { return Input.GetKeyDown(keyToInteract); }
        private bool InteractClicked() { return Input.GetKey(keyToInteract); }
        private bool InteractRelase() { return Input.GetKeyUp(keyToInteract); }

    }
}
