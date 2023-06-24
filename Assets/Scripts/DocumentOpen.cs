using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DocumentOpen : InteractableObject
{
    private bool _isOpen = false;
    private Animator _animator;

    private void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (NPCTalk._permition)
        {
            //if (!_isOpen)
            //{
            //    //_animator.Play("FileOpen", 0, 0.0f);
            //    _isOpen = true;
                
            //}
            //else
            //{
            //    _animator.Play("FileClose", 0, 0.0f);
            //    _isOpen = false;
            //}
            _isOpen = !_isOpen;
            _animator.SetBool("isOpen", _isOpen);
            OnInteracted?.Invoke();
        }

    }

}
