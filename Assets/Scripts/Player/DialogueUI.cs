using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public Action OnDialogueEnded;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private Button _endButton;

    private void Awake()
    {
        _endButton.onClick.AddListener(() => OnDialogueEnded?.Invoke());
    }

    public void SetDialog(string dialogueText)
    {
        _dialogueText.text = dialogueText;
    }
}
