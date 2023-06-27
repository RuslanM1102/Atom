using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] Animator _questsListAnimator;
    [SerializeField] GameObject _interactHintUI;
    [SerializeField] DialogueUI _dialogueUI;

    public GameObject InteractHintUI { get => _interactHintUI; }
    public DialogueUI DialogueUI { get => _dialogueUI; }

    private void OnShowQuests()
    {
        bool isOpen = _questsListAnimator.GetBool("isOpen");
        _questsListAnimator.SetBool("isOpen", !isOpen);
    }
}
