using AYellowpaper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DocumentOpen : InteractableObject
{
    [SerializeField] private InterfaceReference<ICompleteable, MonoBehaviour> _condition;
    private bool _isOpen = false;
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public override void Interact()
    {
        if(_condition.Value.IsCompleted)
        {
            _isOpen = !_isOpen;
            _animator.SetBool("isOpen", _isOpen);
            OnInteracted?.Invoke();
        }
    }
}
