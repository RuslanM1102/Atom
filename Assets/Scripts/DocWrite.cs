using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocWrite : InteractableObject, ICompleteable
{
    [SerializeField] private Sprite _sprite;
    private SpriteRenderer _objSprite;
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
        _objSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Interact()
    {
        _objSprite.sprite = _sprite;
        IsCompleted = true;
        OnInteracted?.Invoke();
    }
}
