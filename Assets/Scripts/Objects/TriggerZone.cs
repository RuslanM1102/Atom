using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TriggerZone : MonoBehaviour, ICompleteable
{
    [SerializeField] private bool _isResetable = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            IsCompleted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isResetable && other.TryGetComponent<PlayerMovement>(out PlayerMovement player))
        {
            IsCompleted = false;
        }
    }
}
