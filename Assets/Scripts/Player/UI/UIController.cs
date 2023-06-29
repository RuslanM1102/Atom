using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour
{
    [SerializeField] private Animator _questsListAnimator;
    [SerializeField] private GameObject _interactHintUI;
    [SerializeField] private DialogueUI _dialogueUI;
    [SerializeField] private InventoryUI _inventoryUI;
    private PlayerInput _playerInput;

    public GameObject InteractHintUI { get => _interactHintUI;}
    public DialogueUI DialogueUI { get => _dialogueUI;}
    public InventoryUI InventoryUI { get => _inventoryUI;}
    private void Start()
    {
        _playerInput = Root.Instance.Player.PlayerInput;
        _playerInput.actions["ShowQuests"].performed += ctx => OnShowQuests();
    }

    private void OnShowQuests()
    {
        bool isOpen = _questsListAnimator.GetBool("isOpen");
        _questsListAnimator.SetBool("isOpen", !isOpen);
    }
}