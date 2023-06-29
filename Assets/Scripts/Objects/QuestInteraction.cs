using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableObject))]
public class QuestInteraction : MonoBehaviour, ICompleteable
{
    private InteractableObject _interactable;
    private bool _isCompleted;
    public Action OnCompleted { get; set; }
    public bool IsCompleted
    {
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

    private void Awake()
    {
        _interactable = GetComponent<InteractableObject>();
        _interactable.OnInteracted += () => IsCompleted = true;
    }
}
