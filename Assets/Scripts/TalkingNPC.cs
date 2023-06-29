using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingNPC : InteractableObject, ICompleteable
{
    [SerializeField] private Dialogue _dialogue;
    private DialogueUI _dialogueUI;
    private UIController _mainUI;
    private PlayerController _playerController;
    private bool _isCompleted;
    public Action OnCompleted { get; set; }
    public bool IsCompleted { 
        get => _isCompleted; 
        private set 
        {
            _isCompleted = value;
            if (_isCompleted)
            {
                OnCompleted?.Invoke();
            }
        } 
    }

    private void Start()
    {
        IsCompleted = false;
        _playerController = Root.Instance.Player;
        _mainUI = Root.Instance.MainUI;
        _dialogueUI = Root.Instance.MainUI.DialogueUI;
    }

    public override void Interact()
    {
        _playerController.TurnPlayer();
        Cursor.lockState = CursorLockMode.None;
        _dialogueUI.SetDialog(_dialogue);
        _dialogueUI.gameObject.SetActive(true);
        _dialogueUI.OnDialogueEnded += EndDialog;
        _mainUI.gameObject.SetActive(false);
        
        OnInteracted?.Invoke();
    }

    public void EndDialog()
    {
        _playerController.TurnPlayer();
        Cursor.lockState = CursorLockMode.Locked;
        _dialogueUI.OnDialogueEnded -= EndDialog;
        _dialogueUI.gameObject.SetActive(false);
        _mainUI.gameObject.SetActive(true);
        IsCompleted = true;
    }
}
